using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tata.Helpers
{
    public static class Utilities
    {
        public static List<KeyValuePair<string, int>> EnumToKeyValuePairs(Type enumType)
        {
            var list = new List<KeyValuePair<string, int>>();
            foreach (var e in Enum.GetValues(enumType))
            {
                list.Add(new KeyValuePair<string, int>(e.ToString(), (int)e));
            }

            return list;
        }
    }
}
