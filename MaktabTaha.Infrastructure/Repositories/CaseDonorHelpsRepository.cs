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
    public class CaseDonorHelpsRepository : GenericRepository<int, CaseDonorHelps>, ICaseDonorHelpsRepository
    {
        private readonly ApplicationDbContext _context;
        public CaseDonorHelpsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<CaseDonorHelps>> GetAllCaseHelps(string caseNumber)
        {
            return await _context.CaseDonorHelps
                .Where(x => x.CaseNumber == caseNumber)
                .ToListAsync();
        }
    }
}
