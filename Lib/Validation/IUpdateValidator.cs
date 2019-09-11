using System.Threading.Tasks;
using Lib.BaseEntities;

namespace Lib.Validation
{
    public interface IUpdateValidator<TVm>
        where TVm: VmBase
    {
        Task Validate(TVm input);
    }
}
