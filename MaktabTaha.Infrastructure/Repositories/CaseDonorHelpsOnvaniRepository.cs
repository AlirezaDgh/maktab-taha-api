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
    public class CaseDonorHelpsOnvaniRepository : GenericRepository<int, CaseDonorHelpsOnvani>, ICaseDonorHelpsOnvaniRepository
    {
        private readonly ApplicationDbContext _context;
        public CaseDonorHelpsOnvaniRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<CaseDonorHelpsOnvani>> GetAllCaseHelpsOnvani(int id)
        {
            return await _context.CaseDonorHelpsOnvani
                .Where(x => x.OnvaniPageId == id)
                .ToListAsync();
        }
    }
}
