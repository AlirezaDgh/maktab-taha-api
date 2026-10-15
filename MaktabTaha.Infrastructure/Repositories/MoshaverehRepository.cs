using MaktabTaha.Application.DTO_s.Moshavereh.List;
using MaktabTaha.Application.DTO_s.Moshavereh.Search;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MaktabTaha.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavereh = MaktabTaha.Domain.Entites.Moshavereh;

namespace MaktabTaha.Infrastructure.Repositories
{
    public class MoshaverehRepository : GenericRepository<int, Moshavereh>, IMoshaverehRepository
    {
        private readonly ApplicationDbContext _context;
        public MoshaverehRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Moshavereh> GetWithAttach(int id)
        {
            return await _context.Moshavereh
                                 .Include(x => x.Attachments)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MoshaverehListDTO>> SearchMoshaverehList(MoshaverehSearchDTO filters)
        {
            var query = _context.Moshavereh
                .Where(x => x.Case.CaseStageId == 1)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.CaseNumber))
            {
                var caseNumber = filters.CaseNumber.Trim();
                query = query.Where(x => x.CaseNumber != null &&
                                    x.CaseNumber.Contains(caseNumber));
            }

            if (!string.IsNullOrWhiteSpace(filters.SupervisorFirstName))
            {
                var firstName = filters.SupervisorFirstName.Trim();
                query = query.Where(x => x.Case
                                          .CasePersons.Any(x => x.Relation.Id == 1 &&
                                                           x.Person.FirstName.Contains(firstName)));
            }

            if (!string.IsNullOrWhiteSpace(filters.SupervisorLastName))
            {
                var lastName = filters.SupervisorLastName.Trim();
                query = query.Where(x => x.Case
                                          .CasePersons.Any(x => x.RelationId == 1 &&
                                                           x.Person.LastName.Contains(lastName)));
            }

            if (!string.IsNullOrWhiteSpace(filters.MoshaverCode))
            {
                var moshaverCode = filters.MoshaverCode.Trim();
                query = query.Where(x => x.MoshaverCode != null &&
                                    x.MoshaverCode.Contains(moshaverCode));
            }

            return await query
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new
                {
                    Case = x,
                    Supervisor = x.Case.CasePersons
                                       .Where(x => x.RelationId == 1)
                                       .Select(x => x.Person)
                                       .SingleOrDefault()
                })
                .Select(x => new MoshaverehListDTO
                {
                    Id = x.Case.Id,
                    CaseNumber = x.Case.CaseNumber,
                    SupervisorFirstName = x.Supervisor.FirstName ?? string.Empty,
                    SupervisorLastName = x.Supervisor.LastName ?? string.Empty,
                    MoshaverehDate = x.Case.CreatedDate
                }).ToListAsync();
        }

        public async Task<Moshavereh> FirstOrDefaultWith(string caseNumber)
        {
            return await _context.Moshavereh
                .Include(x => x.Case)
                .FirstOrDefaultAsync(x => x.CaseNumber == caseNumber);
                
        }
    }
}
