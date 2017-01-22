using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Models;

namespace Tata.Entities
{
    public class UserProduct : Tracking
    {
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
