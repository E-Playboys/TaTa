using Tata.Entities.Enums;

namespace Tata.Entities
{
    public class ProductProperty : Tracking
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

        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
