using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Models.PaymentModels
{
    public class PaymentCompleteViewModel
    {
        public string ClientName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string OrderCode { get; set; }

        public decimal NetTotal { get; set; }

        public decimal Vat { get; set; }

        public decimal GrossTotal { get; set; }

        public Currency Currency { get; set; }

        public string CurrencyName => Currency == Currency.VND ? "vnđ" : "$";

        public PaymentType PaymentType { get; set; }

        private List<PaymentCartItem> _items;
        public List<PaymentCartItem> Items
        {
            get { return _items ?? (_items = new List<PaymentCartItem>()); }
            set { _items = value; }
        }
    }
}
