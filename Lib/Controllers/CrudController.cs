using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.BaseEntities;
using Lib.CrudHandlers;
using Lib.Exceptions;
using Lib.Mediator;
using Lib.Paging;
using Microsoft.AspNetCore.Mvc;

namespace Lib.Controllers
{
    public class CrudController<TVm, TCore> : Controller
        where TVm: VmBase
        where TCore: CoreBase
    {
        private readonly IMediator _mediator;

        public CrudController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public virtual async Task<TVm> Create([FromBody] TVm vm)
        {
            return await _mediator.Send<TVm, TVm,
                ICrudCreate<TVm, TCore>>(vm);
        }

        [HttpGet("{id}")]
        public virtual async Task<TVm> Read(string id)
        {
            return await _mediator.Send<string, TVm,
                ICrudRead<TVm, TCore>>(id);
        }

        [HttpPut("{id}")]
        public virtual async Task<TVm> Update([FromBody] TVm vm, string id)
        {
            if (id != vm.Id)
            {
                throw new ValidationExeption(typeof(TVm), new Dictionary<string, string>
                {
                    ["Id"] = "The 'Id' provided in the URL differs from one provided in the model."
                });
            }

            return await _mediator.Send<TVm, TVm,
                ICrudUpdate<TVm, TCore>>(vm);
        }

        [HttpDelete("{id}")]
        public virtual async Task<TVm> Delete(string id)
        {
            return await _mediator.Send<string, TVm,
                ICrudDelete<TVm, TCore>>(id);
        }

        [HttpPost("list")]
        public virtual async Task<List<TVm>> List(PageInfo pageInfo)
        {
            return await _mediator.Send<PageInfo, List<TVm>,
                ICrudList<TVm, TCore>>(pageInfo);
        }
    }
}
