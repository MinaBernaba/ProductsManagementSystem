using System.Linq.Expressions;

namespace ProductsProject.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAllNoTracking();
        IQueryable<T> GetAllAsTracking();
        Task<bool> IsExist(Expression<Func<T, bool>> match);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);
        void DeleteRange(IEnumerable<T> entities);

    }
}
