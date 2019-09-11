using Lib.BaseEntities;
using Lib.Mediator;

namespace Lib.CrudHandlers
{
    public interface ICrudDelete<TVm, TCore> : IHandler<string, TVm>
        where TVm: VmBase
        where TCore: CoreBase
    {
    }
}
