using System.Collections.Generic;

namespace X12ResourceTool.Spec
{
    public static class Extensions
    {
        public static string JoinStrings<T>(this IEnumerable<T> items, string delimiter) =>
            items == null? null : string.Join(delimiter, items);
    }
}
