using System.Threading.Tasks;
using Lib.BaseEntities;

namespace Lib.Db
{
    public interface IDbRead<T>
        where T: CoreBase
    {
        Task<T> Read(string id);
    }
}
