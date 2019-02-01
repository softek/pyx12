using System.Collections.Generic;

namespace X12ResourceTool
{
    internal static class Extensions
    {
        public static string JoinStrings<T>(this IEnumerable<T> items, string delimiter) =>
            items == null? null : string.Join(delimiter, items);

        public static IReadOnlyList<T> OrEmpty<T>(this IReadOnlyList<T> items) =>
            items ?? new T[0];
    }
}
