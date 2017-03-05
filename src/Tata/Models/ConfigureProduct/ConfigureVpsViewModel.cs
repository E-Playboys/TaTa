using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Models.ProductModels;

namespace Tata.Models.ConfigureProduct
{
    public class ConfigureVpsViewModel
    {
        public int ProductId { get; set; }

        private List<ProductPropertyGroupModel> _requiredPropertyGroups;
        public List<ProductPropertyGroupModel> RequiredPropertyGroups
        {
            get { return _requiredPropertyGroups ?? (_requiredPropertyGroups = new List<ProductPropertyGroupModel>()); }
            set { _requiredPropertyGroups = value; }
        }

        private List<ProductPropertyGroupModel> _optionalPropertyGroups;
        public List<ProductPropertyGroupModel> OptionalPropertyGroups
        {
            get { return _optionalPropertyGroups ?? (_optionalPropertyGroups = new List<ProductPropertyGroupModel>()); }
            set { _optionalPropertyGroups = value; }
        }
    }
}
