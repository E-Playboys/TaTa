using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tata.Entities
{
    public class ProductCategory : Tracking
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public List<Product> Products { get; set; }
    }
}
