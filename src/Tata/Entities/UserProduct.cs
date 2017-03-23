using System;
using System.Collections.Generic;
using TaTa.DataAccess.Entities;

namespace Tata.Entities
{
    public class UserProduct : Tracking
    {
        public DateTime InvoiceDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }

        public string OrderCode { get; set; }
        public string IpAdress { get; set; }
        public string VpsUsername { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public List<ProductProperty> ExtraProperties { get; set; }
    }
}
