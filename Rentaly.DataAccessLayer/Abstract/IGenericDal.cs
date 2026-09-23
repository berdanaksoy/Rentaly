using System.Linq.Expressions;

namespace Rentaly.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task InsertAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task<List<T>> GetListAsync();
        Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T?> GetByIdAsync(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    }
}