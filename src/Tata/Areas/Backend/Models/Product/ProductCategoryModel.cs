using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tata.Areas.Backend.Models.Product
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
