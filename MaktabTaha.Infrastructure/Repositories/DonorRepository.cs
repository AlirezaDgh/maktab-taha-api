using MaktabTaha.Application.DTO_s.donor.List;
using MaktabTaha.Application.DTO_s.donor.Search;
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
    public class DonorRepository : GenericRepository<int, Donor>, IDonorRepository
    {
        private readonly ApplicationDbContext _context;
        public DonorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DonorListDTO>> SearchDonorList(DonorSearchDTO filters)
        {
            var query = _context.Donor
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(filters.NationalCode))
            {
                var nationalCode = filters.NationalCode.Trim();
                query = query.Where(x => x.NationalCode != null &&
                                    x.NationalCode.Contains(nationalCode));
            }

            if (!string.IsNullOrWhiteSpace(filters.FirstName))
            {
                var firstName = filters.FirstName.Trim();
                query = query.Where(x => x.Firstname != null &&
                                    x.Firstname.Contains(firstName));
            }

            if (!string.IsNullOrWhiteSpace(filters.LastName))
            {
                var lastName = filters.LastName.Trim();
                query = query.Where(x => x.Lastname!= null &&
                                    x.Lastname.Contains(lastName));
            }

            if (!string.IsNullOrWhiteSpace(filters.FatherName))
            {
                var fatherName = filters.FatherName.Trim();
                query = query.Where(x => x.FatherName != null &&
                                    x.FatherName.Contains(fatherName));
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
                .Select(x => new DonorListDTO
                {
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    FatherName = x.FatherName,
                    NationalCode = x.NationalCode,
                    GenderId = x.GenderId,
                    GenderName = x.Gender.GenderName,
                    BirthDate = x.BirthDate,
                    CreatedDate = x.CreatedDate
                }).ToListAsync();



        }
    }
}
