using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;
using Tata.Models.SessionModels;

namespace Tata.Models.PaymentModels
{
    public class PaymentCartViewModel
    {
        public decimal NetTotal { get; set; }

        public decimal Vat { get; set; }

        public decimal GrossTotal { get; set; }

        public Currency Currency { get; set; }

        private List<PaymentCartItem> _items;
        public List<PaymentCartItem> Items
        {
            get { return _items ?? (_items = new List<PaymentCartItem>()); }
            set { _items = value; }
        }
    }

    public class PaymentCartItem
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public ProductPriceSessionModel Price { get; set; }

        private List<PaymentCartItem> _subItems;
        public List<PaymentCartItem> SubItems
        {
            get { return _subItems ?? (_subItems = new List<PaymentCartItem>()); }
            set { _subItems = value; }
        }
    }
}
