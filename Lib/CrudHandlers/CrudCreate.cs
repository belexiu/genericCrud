
using System.Threading.Tasks;
using Lib.BaseEntities;
using Lib.Db;
using Lib.Mapping;
using Lib.Validation;

namespace Lib.CrudHandlers
{
    public class CrudCreate<TVm, TCore> : ICrudCreate<TVm, TCore>
        where TVm : VmBase
        where TCore : CoreBase
    {
        private readonly ICreateValidator<TVm> _createValidator;
        private readonly IMapper<TVm, TCore> _mapper;
        private readonly IDbCreate<TCore> _dbCreate;

        public CrudCreate(
            ICreateValidator<TVm> createValidator,
            IMapper<TVm, TCore> mapper,
            IDbCreate<TCore> dbCreate)
        {
            _createValidator = createValidator;
            _mapper = mapper;
            _dbCreate = dbCreate;
        }

        public async Task<TVm> Process(TVm input)
        {
            await _createValidator.Validate(input);

            var coreModel = await _mapper.ToCoreModel(input);

            var dbResult = await _dbCreate.Create(coreModel);

            var vmResult = await _mapper.ToViewModel(dbResult);

            return vmResult;
        }
    }
}
