using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Areas.Backend.Models.Order
{
    public class UpdateOrderStatusModel
    {
        public int OrderId { get; set; }
        public OrderStatus CurrentStatus { get; set; }
    }

    public class UpdateOrderItemStatusModel
    {
        public int OrderItemId { get; set; }

        public OrderItemStatus CurrentStatus { get; set; }

        public string VpsIpAddress { get; set; }
        public string VpsUsername { get; set; }
        public string VpsPassword { get; set; }
    }
}
