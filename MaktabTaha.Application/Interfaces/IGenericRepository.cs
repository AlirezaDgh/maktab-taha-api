using System.Linq.Expressions;

namespace MaktabTaha.Application.Interfaces
{
    public interface  IGenericRepository<TKey, T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<T> GetBy(TKey id);
        Task<List<T>> List();
        Task<List<T>> ListWithoutIsDeleted();
        Task SaveChanges();
        Task<bool> Exists(Expression<Func<T, bool>> expression);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> expression);
        Task<T> SingleOrDefault(Expression<Func<T, bool>> expression);
        Task<T> FirstOrDefaultWithTrack(Expression<Func<T, bool>> expression);
    }
}
