using MaktabTaha.Application.DTO_s.person.List;
using MaktabTaha.Application.DTO_s.person.Search;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MaktabTaha.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Infrastructure.Repositories
{
    public class PersonRepository : GenericRepository<int, Person>, IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<List<PersonListDTO>> SearchPerson(SearchPersonListDTO filters)
        {
            var query = _context.Person
                                    .AsNoTracking()
                                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.NationalCode))
            {
                var nationalCode = filters.NationalCode.Trim();
                query = query.Where(x => x.NationalCode != null && x.NationalCode.Contains(nationalCode));
            }

            if (!string.IsNullOrWhiteSpace(filters.FirstName))
            {
                var firstName = filters.FirstName.Trim();
                query = query.Where(x => x.FirstName != null && x.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrWhiteSpace(filters.LastName))
            {
                var lastName = filters.LastName.Trim();
                query = query.Where(x => x.LastName != null && x.LastName.Contains(lastName));
            }

            if (filters.FromDate.HasValue)
            {
                var fromDate = filters.FromDate.Value.Date;
                query = query.Where(x => x.CreatedDate >= fromDate);
            }

            if (filters.ToDate.HasValue)
            {
                var toDate = filters.ToDate.Value.Date.AddDays(1);
                query = query.Where(x => x.CreatedDate < toDate);
            }

            return await query
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new PersonListDTO
                {
                    Id = x.Id,
                    NationalCode = x.NationalCode ?? string.Empty,
                    FirstName = x.FirstName ?? string.Empty,
                    LastName = x.LastName ?? string.Empty,
                    NickName = x.NickName ?? string.Empty,
                    FatherName = x.FatherName ?? string.Empty,
                    GenderId = x.GenderId,
                    GenderTitle = x.Gender.GenderName,
                    RecordDate = x.CreatedDate
                }).ToListAsync();

        }


        public async Task<List<SearchCasePersonListDTO>> SearchCasePerson(SearchCasePersonListDTO filters)
        {
            var query = _context.Person
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.NationalCode))
            {
                var nationalCode = filters.NationalCode.Trim();
                query = query.Where(x => x.NationalCode != null && x.NationalCode.Contains(nationalCode));
            }

            if (!string.IsNullOrWhiteSpace(filters.FirstName))
            {
                var firstName = filters.FirstName.Trim();
                query = query.Where(x => x.FirstName != null && x.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrWhiteSpace(filters.LastName))
            {
                var lastName = filters.LastName.Trim();
                query = query.Where(x => x.LastName != null && x.LastName.Contains(lastName));
            }

            return await query
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new SearchCasePersonListDTO
                {
                    NationalCode = x.NationalCode ?? string.Empty,
                    FirstName = x.FirstName ?? string.Empty,
                    LastName = x.LastName ?? string.Empty
                }).ToListAsync();
        }
    }
}
