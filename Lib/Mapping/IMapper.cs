using System.Threading.Tasks;
using Lib.BaseEntities;

namespace Lib.Mapping
{
    public interface IMapper<TVm, TCore>
        where TCore: CoreBase
        where TVm: VmBase
    {
        Task ToViewModel(TCore src, ref TVm dst);

        Task ToCoreModel(TVm src, ref TCore dst);


        Task<TVm> ToViewModel(TCore src);

        Task<TCore> ToCoreModel(TVm src);
    }
}
