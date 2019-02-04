using System;
using System.Collections.Generic;
using System.Linq;

namespace X12ResourceTool
{
    using Selector = Func<IEnumerable<string>,string>;
    public static class ResourceFormatting
    {
        public static Dictionary<string,Selector> Selector = new Dictionary<string, Selector>
        {
            {"First", Enumerable.First},
            {"OnlyOrEmpty", OnlyOrEmpty},
            {"OnlyOrUncertain", OnlyOrUncertain},
            {"Commas", Csv},
        };

        static string OnlyOrEmpty(IEnumerable<string> items)
        {
            var i = 0;
            string only = null;
            foreach (var item in items)
            {
                if (i > 0)
                    return "";
                only = item;
                ++i;
            }

            return only;
        }

        private static string OnlyOrUncertain(IEnumerable<string> items)
        {
            // Return the most common item, but indicate uncertainty when there is some.
            var i = 0;
            string only = null;
            foreach (var item in items)
            {
                if (i > 0)
                    return only + " *"; 
                only = item;
                ++i;
            }

            return only;
        }

        private static string Csv(IEnumerable<string> ss) =>
            string.Join(", ", ss);
    }
}
