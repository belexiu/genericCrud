using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lib.Controllers;
using Lib.Mediator;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route(nameof(OrderVm))]
    public class OrderController : CrudController<OrderVm, Order>
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }
    }
}
