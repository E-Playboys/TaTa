using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Areas.Backend.Models.Product
{
    public class ProductPropertyGroupValueModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public Currency Currency { get; set; }
    }
}
