using System.Threading.Tasks;
using Lib.BaseEntities;
using Lib.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Lib.Db
{
    public class DbDelete<T> : IDbDelete<T>
        where T : CoreBase
    {
        private readonly DbContext _dbContext;

        public DbDelete(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Delete(string id)
        {
            var dbEntity = await _dbContext.Set<T>().FindAsync(id);

            if (dbEntity == null)
            {
                throw new NotFoundExeption(id);
            }

            _dbContext.Set<T>().Remove(dbEntity);

            await _dbContext.SaveChangesAsync();

            return dbEntity;
        }
    }
}
