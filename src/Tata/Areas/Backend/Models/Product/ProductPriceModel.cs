using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Areas.Backend.Models.Product
{
    public class ProductPriceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Quantity { get; set; }
        public string Unit { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Priority { get; set; }

        public bool IsDefault { get; set; }
        public bool IsDisabled { get; set; }
        public string ProductName { get; set; }

        public bool NeedDelete { get; set; }
    }
}
