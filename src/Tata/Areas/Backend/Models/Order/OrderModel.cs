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

        public int BillingId { get; set; }
        public BillingModel Billing { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
    }
}
