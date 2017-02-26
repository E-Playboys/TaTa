using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Entities
{
    public class ProductPropertyGroup : Tracking
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductPropertyGroupType Type { get; set; }
        public bool ForDefaultSetup { get; set; }
        public bool ForUserCustomize { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public List<ProductPropertyGroupValue> Values { get; set; }
    }
}
