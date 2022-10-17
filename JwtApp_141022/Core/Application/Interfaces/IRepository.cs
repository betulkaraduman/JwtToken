using JwtApp_141022.Core.Domain;
using System.Linq.Expressions;

namespace JwtApp_141022.Core.Application.Interfaces
{
    public interface IRepository<T> where T : BaseClass,new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int Id);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> predicate);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
