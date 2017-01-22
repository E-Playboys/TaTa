using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tata.Entities
{
    public class OrderItem : Tracking
    {
        public int Quantity { get; set; }
        public int ProductPriceId { get; set; }
        public ProductPrice ProductPrice { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
