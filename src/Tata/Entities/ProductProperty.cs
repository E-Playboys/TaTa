namespace Tata.Entities
{
    public class ProductProperty : Tracking
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; }
        public int Priority { get; set; }
        public bool IsHighlight { get; set; }
        public bool IsDisabled { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
