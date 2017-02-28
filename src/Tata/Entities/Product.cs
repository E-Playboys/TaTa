using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Entities
{
    public class Product : Tracking
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string MetaTagTitle { get; set; }
        public string MetaTagDescription { get; set; }
        public string MetaTagKeywords { get; set; }
        public int Priority { get; set; }
        public ProductStatus Status { get; set; }

        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        private List<ProductProperty> _properties;
        public List<ProductProperty> Properties
        {
            get { return _properties ?? (_properties = new List<ProductProperty>()); }
            set { _properties = value; }
        }

        private List<ProductPrice> _prices;
        public List<ProductPrice> Prices
        {
            get { return _prices ?? (_prices = new List<ProductPrice>()); }
            set { _prices = value; }
        }
    }
}
