using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Models.PaymentModels
{
    public class PaymentSelectionViewModel
    {
        public string ClientName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}
