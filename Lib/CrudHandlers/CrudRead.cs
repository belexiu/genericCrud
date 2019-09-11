using System.Threading.Tasks;
using Lib.BaseEntities;
using Lib.Db;
using Lib.Mapping;

namespace Lib.CrudHandlers
{
    public class CrudRead<TVm, TCore> : ICrudRead<TVm, TCore>
        where TVm : VmBase
        where TCore : CoreBase
    {
        private readonly IDbRead<TCore> _dbRead;
        private readonly IMapper<TVm, TCore> _mapper;

        public CrudRead(IDbRead<TCore> dbRead,
            IMapper<TVm, TCore> mapper)
        {
            _dbRead = dbRead;
            _mapper = mapper;
        }

        public async Task<TVm> Process(string input)
        {
            var dbResult = await _dbRead.Read(input);

            var vmResult = await _mapper.ToViewModel(dbResult);

            return vmResult;
        }
    }
}
