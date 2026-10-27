using MaktabTaha.Application.Interfaces.Repositories.BaseEntities;
using MaktabTaha.Domain.Entites.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace MaktabTaha.Infrastructure.Repositories.baseEntities
{
    public class DonorTypeRepository : GenericRepository<int, DonorType>, IDonorTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public DonorTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
