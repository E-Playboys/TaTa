using System;
using TaTa.DataAccess.Entities;

namespace Tata.Entities
{
    public class UserProduct : Tracking
    {
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
