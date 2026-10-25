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
    }
}
