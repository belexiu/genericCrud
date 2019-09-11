using System.Threading.Tasks;
using Lib.BaseEntities;

namespace Lib.Db
{
    public interface IDbDelete<T>
        where T: CoreBase
    {
        Task<T> Delete(string id);
    }
}
