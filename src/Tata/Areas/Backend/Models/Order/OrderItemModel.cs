using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Areas.Backend.Models.Product;

namespace Tata.Areas.Backend.Models.Order
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductPriceId { get; set; }
        public ProductPriceModel ProductPrice { get; set; }
    }
}
