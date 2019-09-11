using System.Threading.Tasks;
using Lib.BaseEntities;
using Lib.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Lib.Db
{
    public class DbRead<T> : IDbRead<T>
        where T: CoreBase
    {
        private readonly DbContext _dbContext;

        public DbRead(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Read(string id)
        {
            var dbResult = await _dbContext.Set<T>().FindAsync(id);

            if (dbResult == null)
            {
                throw new NotFoundExeption(id);
            }

            return dbResult;
        }
    }
}
