using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;
using Tata.Models.ProductModels;

namespace Tata.Areas.Backend.Models.Product
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string MetaTagTitle { get; set; }

        [Required]
        public string MetaTagDescription { get; set; }

        [Required]
        public string MetaTagKeywords { get; set; }

        public int Priority { get; set; }
        public ProductStatus Status { get; set; }
        public int CategoryId { get; set; }

        private List<ProductPropertyModel> _properties;
        public List<ProductPropertyModel> Properties
        {
            get
            {
                if (_properties == null)
                    _properties = new List<ProductPropertyModel>();

                // Always have an empty row here for the user to input 
                // and Add More button can also leverage this empty row to clone a new row
                if (_properties.All(x => x.Id != 0))
                {
                    _properties.Add(new ProductPropertyModel());
                }

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
