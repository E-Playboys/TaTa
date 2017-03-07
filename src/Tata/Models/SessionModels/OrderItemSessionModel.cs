using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Areas.Backend.Models.Product;
using Tata.Entities.Enums;
using Tata.Models.ProductModels;

namespace Tata.Models.SessionModels
{
    public class OrderItemSessionModel
    {
        public ProductSessionModel Product { get; set; }

        public int Quantity { get; set; } = 1;

        private List<PropertySessionModel> _properties;
        public List<PropertySessionModel> Properties
        {
            get { return _properties ?? (_properties = new List<PropertySessionModel>()); }
            set { _properties = value; }
        }
    }

    public class ProductSessionModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductPriceSessionModel Price { get; set; }

        public string Category  { get; set; }
    }

    public class ProductPriceSessionModel
    {
        public decimal Price { get; set; }

        public Currency Currency { get; set; }
    }

    public class PropertySessionModel
    {
        public ProductPropertyGroupType Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public ProductPriceSessionModel Price { get; set; }
        public string Unit { get; set; }
    }
}
