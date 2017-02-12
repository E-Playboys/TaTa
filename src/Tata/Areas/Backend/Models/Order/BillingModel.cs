using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tata.Areas.Backend.Models.Order
{
    public class BillingModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
