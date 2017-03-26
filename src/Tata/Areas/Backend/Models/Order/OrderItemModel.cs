using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Areas.Backend.Models.Product;
using Tata.Entities.Enums;
using Tata.Models.ProductModels;

namespace Tata.Areas.Backend.Models.Order
{
    public class OrderItemModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public OrderItemStatus Status { get; set; }

        public ProductModel Product { get; set; }

        public List<ProductPropertyModel> ExtraProperties { get; set; }
    }
}
