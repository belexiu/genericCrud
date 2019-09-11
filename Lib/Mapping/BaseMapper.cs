using System.Threading.Tasks;
using Lib.BaseEntities;

namespace Lib.Mapping
{
    public abstract class BaseMapper<TVm, TCore> : IMapper<TVm, TCore>
        where TVm: VmBase, new()
        where TCore: CoreBase, new()
    {
        public abstract Task ToCoreModel(TVm src, ref TCore dst);

        public abstract Task ToViewModel(TCore src, ref TVm dst);


        public async Task<TCore> ToCoreModel(TVm src)
        {
            var dst = new TCore();

            await ToCoreModel(src, ref dst);

            return dst;
        }


        public async Task<TVm> ToViewModel(TCore src)
        {
            var dst = new TVm();

            await ToViewModel(src, ref dst);

            return dst;
        }
    }
}
