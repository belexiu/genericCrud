using System.Collections.Generic;
using Lib.BaseEntities;

namespace WebApi.Models
{
    public class Product : CoreBase
    {
        public string Name { get; set; }


        public List<Order> Orders { get; set; }
    }
}
