using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Entities
{
    public class ProductPrice : Tracking
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public int UnitQuantity { get; set; }
        public string Unit { get; set; }
        public int Priority { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDisabled { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
