using MaktabTaha.Application.DTO_s.tahghigh.List;
using MaktabTaha.Application.DTO_s.tahghigh.Search;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Infrastructure.Repositories
{
    public class TahghighRepository : GenericRepository<int, Tahghigh>, ITahghighRepository
    {
        private readonly ApplicationDbContext _context;
        public TahghighRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tahghigh> FirstOrDefaultWith(string caseNumber)
        {
            return await _context.Tahghigh
                .Include(x => x.Moshavereh)
                .ThenInclude(x => x.Case)
                .FirstOrDefaultAsync(x => x.Moshavereh.Case.CaseNumber == caseNumber);
        }

        public async Task<List<TahghighListDTO>> GetAllTahghighList(SearchTahghighDTO filters)
        {
            var query = _context.Tahghigh
                .AsNoTracking()
                .Where(x => x.Moshavereh.Case.CaseStageId == 3);

            if (!string.IsNullOrWhiteSpace(filters.CaseNumber))
            {
                var caseNumber = filters.CaseNumber.Trim();
                query = query.Where(x => x.Moshavereh.CaseNumber != null &&
                                    x.Moshavereh.CaseNumber.Contains(caseNumber));
            }

            if (!string.IsNullOrWhiteSpace(filters.SupervisorFirstName))
            {
                var firstName = filters.SupervisorFirstName.Trim();
                query = query.Where(x => x.Moshavereh.Case.CasePersons
                                                .Any(x => x.RelationId == 1 &&
                                                     x.Person.FirstName != null &&
                                                     x.Person.FirstName.Contains(firstName)));

            }

            if (!string.IsNullOrWhiteSpace(filters.SupervisorLastName))
            {
                var lastName = filters.SupervisorLastName.Trim();
                query = query.Where(x => x.Moshavereh.Case.CasePersons
                                                .Any(x => x.RelationId == 1 &&
                                                     x.Person.LastName != null &&
                                                     x.Person.LastName.Contains(lastName)));

            }

            if (!string.IsNullOrWhiteSpace(filters.FirstMohagheghCode))
            {
                var firstMohagheghCode = filters.FirstMohagheghCode.Trim();
                query = query.Where(x => x.FirstMohagheghCode != null &&
                                    x.FirstMohagheghCode.Contains(firstMohagheghCode));
            }

            return await query
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new
                {
                    Tahghigh = x,
                    Supervisor = x.Moshavereh.Case.CasePersons
                })
                .Select(x => new TahghighListDTO
                {
                    Id = x.Tahghigh.Id,
                    CaseNumber = x.Tahghigh.Moshavereh.CaseNumber ?? string.Empty,

                    SupervisorFirstName = x.Supervisor
                                                    .Where(x => x.RelationId == 1)
                                                    .Select(x => x.Person.FirstName)
                                                    .SingleOrDefault() ?? string.Empty,
                    
                    SupervisorLastName = x.Supervisor
                                                    .Where(x => x.RelationId == 1)
                                                    .Select(x => x.Person.LastName)
                                                    .SingleOrDefault() ?? string.Empty,
                    
                    TahghighDate = x.Tahghigh.TahghighDate 
                }).ToListAsync();
        }
    }
}
