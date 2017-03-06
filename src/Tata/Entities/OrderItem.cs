using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Entities
{
    public class OrderItem : Tracking
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }

        public List<ProductProperty> ExtraProperties { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
