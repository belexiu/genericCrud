using System.Threading.Tasks;
using Lib.BaseEntities;

namespace Lib.Db
{
    public interface IDbCreate<T>
        where T: CoreBase
    {
        Task<T> Create(T entity);
    }
}
