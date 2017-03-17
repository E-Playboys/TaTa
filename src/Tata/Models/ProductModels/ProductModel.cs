using System.Collections.Generic;
using System.Linq;
using Tata.Areas.Backend.Models.Product;
using Tata.Entities.Enums;

namespace Tata.Models.ProductModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string MetaTagTitle { get; set; }
        public string MetaTagDescription { get; set; }
        public string MetaTagKeywords { get; set; }
        public int Priority { get; set; }
        public ProductStatus Status { get; set; }

        public int CategoryId { get; set; }
        public ProductCategoryModel Category { get; set; }

        private List<ProductPropertyModel> _properties;
        public List<ProductPropertyModel> Properties
        {
            get
            {
                //if(_properties == null)
                //    _properties = new List<ProductPropertyModel>();

                //// Always have an empty row here for the user to input 
                //// and Add More button can also leverage this empty row to clone a new row
                //if (_properties.All(x => x.Id != 0))
                //{
                //    _properties.Add(new ProductPropertyModel());
                //}
                
                return _properties;
            }
            set { _properties = value; }
        }

        private List<ProductPriceModel> _prices;
        public List<ProductPriceModel> Prices
        {
            get
            {
                if (_prices == null)
                    _prices = new List<ProductPriceModel>();

                // Always have an empty row here for the user to input 
                // and Add More button can also leverage this empty row to clone a new row
                if (_prices.All(x => x.Id != 0))
                {
                    _prices.Add(new ProductPriceModel());
                }
                
                return _prices;
            }
            set { _prices = value; }
        }
    }
}
