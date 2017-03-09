using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Models.SessionModels
{
    public class PaymentSessionModel
    {
        public decimal NetTotal { get; set; }

        public decimal Vat { get; set; }

        public decimal GrossTotal { get; set; }

        public Currency Currency { get; set; }

        public string CurrencyName => Currency == Currency.VND ? "vnđ" : "$";

        public PaymentType PaymentType { get; set; }
    }
}
