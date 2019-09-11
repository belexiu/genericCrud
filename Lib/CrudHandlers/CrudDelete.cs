using System.Threading.Tasks;
using Lib.BaseEntities;
using Lib.Db;
using Lib.Mapping;

namespace Lib.CrudHandlers
{
    public class CrudDelete<TVm, TCore> : ICrudDelete<TVm, TCore>
        where TVm : VmBase
        where TCore : CoreBase
    {
        private readonly IDbDelete<TCore> _dbDelete;
        private readonly IMapper<TVm, TCore> _mapper;

        public CrudDelete(IDbDelete<TCore> dbDelete,
            IMapper<TVm, TCore> mapper)
        {
            _dbDelete = dbDelete;
            _mapper = mapper;
        }

        public async Task<TVm> Process(string input)
        {
            var dbResult = await _dbDelete.Delete(input);

            var vmResult = await _mapper.ToViewModel(dbResult);

            return vmResult;
        }
    }
}
