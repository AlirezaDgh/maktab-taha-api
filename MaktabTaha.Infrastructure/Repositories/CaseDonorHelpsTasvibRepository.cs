using MaktabTaha.Application.DTO_s.caseDonorHelps.List;
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
    public class CaseDonorHelpsTasvibRepository : GenericRepository<int, CaseDonorHelpsTasvib>, ICaseDonorHelpsTasvibRepository
    {
        private readonly ApplicationDbContext _context;
        public CaseDonorHelpsTasvibRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<CaseDonorHelpsTasvib>> GetAllCaseHelps(string caseNumber)
        {
            return await _context.CaseDonorHelpsTasvib
                .Where(x => x.CaseNumber == caseNumber)
                .ToListAsync();
        }
    }
}
