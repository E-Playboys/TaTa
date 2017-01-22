using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Entities
{
    public class Order : Tracking
    {
        public int OrderNumber { get; set; }
        public string OrderCode { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public int BillingId { get; set; }
        public Billing Billing { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
