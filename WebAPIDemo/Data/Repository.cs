using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPIDemo.Data
{
    public class Repository<ApplicationDbContext>: IRepository where ApplicationDbContext:DbContext
    {
        protected ApplicationDbContext dbContext;
        public Repository(ApplicationDbContext _dbContext)
        {
            dbContext=_dbContext;
        }

        public async Task CreateAsync<T>(T Entity) where T : class
        {
            dbContext.Set<T>().Add(Entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T Entity) where T : class
        {
          dbContext.Set<T>().Remove(Entity);
          await dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> FindAll<T>() where T : class
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> FindById<T>(int Id) where T : class
        {
            return await dbContext.Set<T>().FindAsync(Id);
        }

        public async Task UpdateAsync<T>(T Entity) where T : class
        {
           dbContext.Set<T>().Update(Entity);
           await dbContext.SaveChangesAsync();
        }
    }
}