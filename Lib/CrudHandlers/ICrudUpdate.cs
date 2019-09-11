using Lib.BaseEntities;
using Lib.Mediator;

namespace Lib.CrudHandlers
{
    public interface ICrudUpdate<TVm, TCore> : IHandler<TVm, TVm>
        where TVm : VmBase
        where TCore : CoreBase
    {
    }
}
