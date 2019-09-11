using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.BaseEntities;
using Lib.Db;
using Lib.Mapping;
using Lib.Paging;
using StaticUtils;

namespace Lib.CrudHandlers
{
    public class CrudList<TVm, TCore> : ICrudList<TVm, TCore>
        where TVm: VmBase
        where TCore: CoreBase
    {
        private readonly IDbList<TCore> _dbList;
        private readonly IMapper<TVm, TCore> _mapper;

        public CrudList(IDbList<TCore> dbList,
            IMapper<TVm, TCore> mapper)
        {
            _dbList = dbList;
            _mapper = mapper;
        }

        public async Task<List<TVm>> Process(PageInfo input)
        {
            var dbResult = await _dbList.List(input);

            var result = await dbResult.SelectAsync(coreModel => _mapper.ToViewModel(coreModel));

            return result;
        }
    }
}
