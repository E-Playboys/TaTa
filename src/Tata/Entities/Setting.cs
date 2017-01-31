using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tata.Entities
{
    public class Setting : Tracking
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string TypeValue { get; set; }
        public string Section { get; set; }
        public int Priority { get; set; }
    }
}
