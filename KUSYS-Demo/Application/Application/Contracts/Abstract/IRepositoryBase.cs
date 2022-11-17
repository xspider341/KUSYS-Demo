using Domain.Base;
using System.Linq.Expressions;

namespace Application.Contracts.Abstract
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(long id);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetByQueryAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
