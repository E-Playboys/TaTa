using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tata.Entities
{
    public class Product : Tracking
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<ProductProperty> ProductProperties { get; set; }
        public List<ProductPrice> ProductPrices { get; set; }
    }
}
