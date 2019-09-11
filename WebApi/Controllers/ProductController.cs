using Lib.Controllers;
using Lib.Mediator;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route(nameof(ProductVm))]
    public class ProductController : CrudController<ProductVm, Product>
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }
    }
}
