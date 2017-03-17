using Tata.Entities.Enums;

namespace Tata.Models.ProductModels
{
    public class ProductPropertyModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public Currency Currency { get; set; }
        public ProductPropertyGroupType Type { get; set; }

        public int Priority { get; set; }
        public bool IsHighlight { get; set; }
        public bool IsDisabled { get; set; }
    }
}
