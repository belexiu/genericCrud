using System.Threading.Tasks;
using Lib.Mapping;
using WebApi.Models;
using WebApi.ViewModels;

namespace WebApi.Mappers
{
    public class ProductMapper : BaseMapper<ProductVm, Product>
    {
        public override Task ToCoreModel(ProductVm src, ref Product dst)
        {
            dst.Name = src.Name;

            return Task.CompletedTask;
        }

        public override Task ToViewModel(Product src, ref ProductVm dst)
        {
            dst.Id = src.Id;
            dst.Name = src.Name;

            return Task.CompletedTask;
        }
    }
}
