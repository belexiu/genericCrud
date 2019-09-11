using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.BaseEntities;
using Lib.Paging;

namespace Lib.Db
{
    public interface IDbList<T>
        where T: CoreBase
    {
        Task<List<T>> List(PageInfo pageInfo);
    }
}
