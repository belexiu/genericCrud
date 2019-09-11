using System.Threading.Tasks;
using Lib.BaseEntities;
using Lib.Db;
using Lib.Mapping;
using Lib.Validation;

namespace Lib.CrudHandlers
{
    public class CrudUpdate<TVm, TCore> : ICrudUpdate<TVm, TCore>
        where TVm : VmBase
        where TCore : CoreBase
    {
        private readonly IUpdateValidator<TVm> _updateValidator;
        private readonly IMapper<TVm, TCore> _mapper;
        private readonly IDbUpdate<TCore> _dbUpdate;
        private readonly IDbRead<TCore> _dbRead;

        public CrudUpdate(
            IUpdateValidator<TVm> updateValidator,
            IMapper<TVm, TCore> mapper,
            IDbUpdate<TCore> dbUpdate,
            IDbRead<TCore> dbRead)
        {
            _updateValidator = updateValidator;
            _mapper = mapper;
            _dbUpdate = dbUpdate;
            _dbRead = dbRead;
        }

        public async Task<TVm> Process(TVm input)
        {
            await _updateValidator.Validate(input);

            var dbModel = await _dbRead.Read(input.Id);

            await _mapper.ToCoreModel(input, ref dbModel);

            var dbResult = await _dbUpdate.Update(dbModel);

            var vmResult = await _mapper.ToViewModel(dbResult);

            return vmResult;
        }
    }
}
