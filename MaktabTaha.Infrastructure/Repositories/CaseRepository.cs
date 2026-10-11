using MaktabTaha.Application.DTO_s.caseDesc.List;
using MaktabTaha.Application.DTO_s.caseDesc.Search;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Infrastructure.Repositories
{
    public class CaseRepository : GenericRepository<int, Case>, ICaseRepository
    {
        private readonly ApplicationDbContext _context;
        public CaseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<CaseListDTO>> SearchCaseList(SearchCaseDTO filters)
        {
            var query = _context.CaseBNF
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.CaseNumber))
            {
                var caseNumber = filters.CaseNumber.Trim();
                query = query.Where(x => x.CaseNumber != null && x.CaseNumber.Contains(caseNumber));
            }

            if (filters.RequestId.HasValue)
            {
                query = query.Where(x => x.RequestId == filters.RequestId.Value);
            }

            if (filters.FromDate.HasValue)
            {
                var fromDate = filters.FromDate.Value.Date;
                query = query.Where(x => x.CreatedDate >=  fromDate);
            }

            if (filters.ToDate.HasValue)
            {
                var toDate = filters.ToDate.Value.Date.AddDays(1);
                query = query.Where(x => x.CreatedDate < toDate);
            }

            if (!string.IsNullOrEmpty(filters.NationalCode))
            {
                var nationalCode = filters.NationalCode.Trim();
                query = query.Where(x => x.CasePersons
                                            .Any(x => x.Person.NationalCode != null &&
                                                 x.Person.NationalCode.Contains(nationalCode)));
            }

            if (!string.IsNullOrWhiteSpace(filters.SupervisorFirstName))
            {
                var firstName = filters.SupervisorFirstName.Trim();
                query = query.Where(x => x.CasePersons
                                                .Any(x => x.Person.FirstName != null &&
                                                     x.Relation.RelationName == "سرپرست" &&
                                                     x.Person.FirstName.Contains(firstName)));
            }

            if (!string.IsNullOrWhiteSpace(filters.SupervisorLastName))
            {
                var lastName = filters.SupervisorLastName.Trim();
                query = query.Where(x => x.CasePersons
                                                .Any(x => x.Person.LastName != null &&
                                                     x.Relation.RelationName == "سرپرست" &&
                                                     x.Person.LastName.Contains(lastName)));
            }

            if (filters.CaseTypeId.HasValue)
            {
                query = query.Where(x => x.CaseTypeId ==  filters.CaseTypeId.Value);
            }

            if (filters.PrivatenessStatusId.HasValue)
            {
                query = query.Where(x => x.PrivatenessStatusId == filters.PrivatenessStatusId.Value);
            }

            return await query
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new CaseListDTO
                {
                    Id = x.Id,

                    CaseNumber = x.CaseNumber ?? string.Empty,

                    RequestId = x.RequestId,

                    CreatedAt = x.CreatedDate,

                    NationalCode = x.CasePersons
                    .Where(x => x.Relation.RelationName == "سرپرست")
                    .Select(x => x.Person.NationalCode)
                    .FirstOrDefault() ?? string.Empty,

                    SupervisorFirstName = x.CasePersons
                    .Where(x => x.Relation.RelationName == "سرپرست")
                    .Select(x => x.Person.FirstName)
                    .FirstOrDefault() ?? string.Empty,

                    SupervisorLastName = x.CasePersons
                    .Where(x => x.Relation.RelationName == "سرپرست")
                    .Select(x => x.Person.LastName)
                    .FirstOrDefault() ?? string.Empty,

                    HouseHeadStatusId = x.HouseHeadStatusId,

                    CaseTypeId = x.CaseTypeId,

                    PrivatenessStatusId = x.PrivatenessStatusId
                }).ToListAsync();
        }
    }
}
