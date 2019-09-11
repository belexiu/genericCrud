using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.BaseEntities;
using Lib.Paging;
using Microsoft.EntityFrameworkCore;

namespace Lib.Db
{
    public class DbList<T> : IDbList<T>
        where T : CoreBase
    {
        private readonly DbContext _dbContext;

        public DbList(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<T>> List(PageInfo pageInfo)
        {
            var all = await _dbContext.Set<T>().ToListAsync();

            return all;
        }
    }
}
