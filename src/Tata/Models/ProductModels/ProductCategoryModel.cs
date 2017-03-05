using System.Collections.Generic;
using Tata.Areas.Backend.Models.Product;

namespace Tata.Models.ProductModels
{
    public class ProductCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public List<ProductPropertyGroupModel> PropertyGroups { get; set; }
    }
}
