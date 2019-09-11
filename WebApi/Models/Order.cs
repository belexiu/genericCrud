using Lib.BaseEntities;

namespace WebApi.Models
{
    public class Order : CoreBase
    {
        public int Quantity { get; set; }


        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
