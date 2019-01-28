using System.Collections.Generic;

namespace X12ResourceTool.Spec.MapV2
{
    public static class Extensions
    {
        public static string JoinStrings(this IEnumerable<T> items, string delimiter) =>
            string.Join(delimiter, items);
    }
}
