using System.ComponentModel.DataAnnotations;
using Tata.Entities.Enums;

namespace Tata.Models.ProductModels
{
    public class ProductPropertyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public Currency Currency { get; set; }
        public ProductPropertyGroupType Type { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Priority { get; set; }

        public bool IsHighlight { get; set; }
        public bool IsDisabled { get; set; }

        public bool NeedDelete { get; set; }
    }
}
