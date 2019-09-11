using System.Threading.Tasks;
using Lib.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Lib.Db
{
    public class DbUpdate<T> : IDbUpdate<T>
        where T : CoreBase
    {
        private readonly DbContext _dbContext;

        public DbUpdate(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
