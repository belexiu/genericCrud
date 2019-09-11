using System.Threading.Tasks;
using Lib.BaseEntities;

namespace Lib.Validation
{
    public class DefaultValidator<T> : ICreateValidator<T>, IUpdateValidator<T>
        where T : VmBase
    {
        public Task Validate(T input)
        {
            return Task.CompletedTask;
        }
    }
}
