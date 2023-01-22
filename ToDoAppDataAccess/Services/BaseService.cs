using Microsoft.EntityFrameworkCore;
using OnsiteDataAccess.AppDataContest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoAppDataAccess.IServices;

namespace ToDoAppDataAccess.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly AppDbContext context;
        public BaseService(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        // Implementing IBaseRepository

        #region Searching
        public async Task<TEntity> Get(int Id)
        {
            return await context.Set<TEntity>().FindAsync(Id);
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }
        public async Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        #endregion

        #region Saving
        public async Task Save(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }
        public async Task SaveAll(IEnumerable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
        }
        #endregion

        #region Deleting
        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }
        public void RemoveAll(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }
        #endregion
    }
}
