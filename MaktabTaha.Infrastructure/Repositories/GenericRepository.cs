using MaktabTaha.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MaktabTaha.Infrastructure.Repositories
{
    public class GenericRepository<TKey, T> : IGenericRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChanges();

            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public async Task<T> GetBy(TKey id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> List()
        {
            return await _context.Set<T>()
                .Where(x => EF.Property<bool>(x, "IsDeleted") == false)
                .ToListAsync();
        }       
        public async Task<List<T>> ListWithoutIsDeleted()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<T> SingleOrDefault(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(expression);
        }
        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>()
                .IgnoreQueryFilters()
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);
        }

        public async Task<T> FirstOrDefaultWithTrack(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(expression);
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
