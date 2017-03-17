using System.Collections.Generic;
using Tata.Entities.Enums;

namespace Tata.Areas.Backend.Models.Order
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string OrderCode { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public decimal GrossTotal { get; set; }
        public decimal NetTotal { get; set; }
        public PaymentType PaymentType { get; set; }

        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }

        public string CurrencyName => OrderItems[0].Currency == Currency.VND ? "vnđ" : "$";
    }
}
