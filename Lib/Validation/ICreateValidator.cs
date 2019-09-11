using System.Threading.Tasks;
using Lib.BaseEntities;

namespace Lib.Validation
{
    public interface ICreateValidator<TVm>
        where TVm: VmBase
    {
        Task Validate(TVm input);
    }
}
