using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Entities
{
    public class ProductPropertyGroupValue : Tracking
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public Currency Currency { get; set; }

        public int GroupId { get; set; }
        public ProductPropertyGroup Group { get; set; }
    }
}
