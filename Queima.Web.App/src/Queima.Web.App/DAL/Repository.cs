using Microsoft.EntityFrameworkCore;
using Queima.Web.App.Helpers;
using Queima.Web.App.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Queima.Web.App.DAL
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private QueimaDbContext _dbContext;
        public Repository(QueimaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().Find(id);
        }

        public async Task Save(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
