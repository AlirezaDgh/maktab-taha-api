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
    public class CasePersonRepository : GenericRepository<int, CasePerson>, ICasePersonRepository
    {
        private readonly ApplicationDbContext _context;
        public CasePersonRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CasePerson> CreateNoSave(CasePerson entity)
        {
            await _context.CasePerson.AddAsync(entity);
            return entity;
        }
    }
}
