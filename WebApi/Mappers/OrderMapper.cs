using System.Threading.Tasks;
using Lib.Mapping;
using WebApi.Models;
using WebApi.ViewModels;

namespace WebApi.Mappers
{
    public class OrderMapper : BaseMapper<OrderVm, Order>
    {
        public override Task ToCoreModel(OrderVm src, ref Order dst)
        {
            dst.Quantity = src.Quantity;
            dst.ProductId = src.ProductId;

            return Task.CompletedTask;
        }

        public override Task ToViewModel(Order src, ref OrderVm dst)
        {
            dst.Id = src.Id;

            dst.Quantity = src.Quantity;
            dst.ProductId = src.ProductId;

            return Task.CompletedTask;
        }
    }
}
