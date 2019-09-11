using System.Collections.Generic;
using Lib.BaseEntities;
using Lib.Mediator;
using Lib.Paging;

namespace Lib.CrudHandlers
{
    public interface ICrudList<TVm, TCore> : IHandler<PageInfo, List<TVm>>
        where TVm: VmBase
        where TCore: CoreBase
    {

    }
}
