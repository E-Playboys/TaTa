using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Areas.Backend.Models.Product
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

        public int ProductCategoryId { get; set; }
        public ProductCategoryModel ProductCategory { get; set; }

        private List<ProductPropertyModel> _productProperties;
        public List<ProductPropertyModel> ProductProperties
        {
            get
            {
                if(_productProperties == null)
                    _productProperties = new List<ProductPropertyModel>();

                // Always have an empty row here for the user to input 
                // and Add More button can also leverage this empty row to clone a new row
                if (_productProperties.All(x => x.Id != 0))
                {
                    _productProperties.Add(new ProductPropertyModel());
                }
                
                return _productProperties;
            }
            set { _productProperties = value; }
        }

        private List<ProductPriceModel> _productPrices;
        public List<ProductPriceModel> ProductPrices
        {
            get
            {
                if (_productPrices == null)
                    _productPrices = new List<ProductPriceModel>();

                // Always have an empty row here for the user to input 
                // and Add More button can also leverage this empty row to clone a new row
                if (_productPrices.All(x => x.Id != 0))
                {
                    _productPrices.Add(new ProductPriceModel());
                }
                
                return _productPrices;
            }
            set { _productPrices = value; }
        }
    }
}
