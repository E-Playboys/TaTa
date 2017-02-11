using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tata.Areas.Backend.Models.Product
{
    public class ProductPropertyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; }
        public int Priority { get; set; }
        public bool IsHighlight { get; set; }
        public bool IsDisabled { get; set; }

        public bool NeedDelete { get; set; }
    }
}
