using System.Threading.Tasks;
using Lib.BaseEntities;

namespace Lib.Db
{
    public interface IDbUpdate<T>
        where T: CoreBase
    {
        Task<T> Update(T entity);
    }
}
