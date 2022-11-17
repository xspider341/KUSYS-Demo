using Application.Contracts.Abstract;
using Domain.Base;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {

        protected readonly ModelContext _context;

        public RepositoryBase(ModelContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null
                 ? _context.Set<T>().ToList()
                 : _context.Set<T>().Where(filter).ToList();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _context.Set<T>().FindAsync(id);

        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByQueryAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }
    }
}
