using Lib.BaseEntities;
using Lib.Mediator;

namespace Lib.CrudHandlers
{
    interface ICrudCreate<TVm, TCore> : IHandler<TVm, TVm>
        where TVm: VmBase
        where TCore: CoreBase
    {
    }
}
