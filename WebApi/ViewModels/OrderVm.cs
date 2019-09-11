using Lib.BaseEntities;

namespace WebApi.ViewModels
{
    public class OrderVm: VmBase
    {
        public int Quantity { get; set; }

        public string ProductId { get; set; }
    }
}
