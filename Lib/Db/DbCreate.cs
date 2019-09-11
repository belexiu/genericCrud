using System.Threading.Tasks;
using Lib.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Lib.Db
{
    public class DbCreate<T> : IDbCreate<T>
        where T: CoreBase
    {
        private readonly DbContext _dbContext;

        public DbCreate(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Create(T entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
