using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using JwtApp_141022.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtApp_141022.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseClass, new()
    {
        private readonly JwtAppDbContext _dbContext;
        public Repository(JwtAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletedEntity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Remove(deletedEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var listEntity = await _dbContext.Set<T>().ToListAsync();
            return listEntity;
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            var entity=await _dbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
            return entity;
        }

        public async Task<T?> GetByIdAsync(int Id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(Id);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            var unchanged = await _dbContext.Set<T>().FindAsync(entity.Id);
            _dbContext.Entry(unchanged).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
