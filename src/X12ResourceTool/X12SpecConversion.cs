using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X12ResourceTool.Spec;

namespace X12ResourceTool
{
    internal static class X12SpecConversion
    {
        public const char PathDelimiter = '_';

        public static IEnumerable<KeyValuePair<string, T>> GetResources<T>(this ITransaction transaction,
            Func<object, T> xform, Func<string, bool> includeSegment) =>
            FlattenLoop(transaction.loop, xform, includeSegment);

        private static IEnumerable<KeyValuePair<string, T>> FlattenLoop<T>(this ILoop loop,
            Func<object, T> xform, Func<string, bool> includeSegment) =>
            loop.Loops.SelectMany(seg => FlattenLoop(seg, xform, includeSegment))
                .Concat(loop.Segments.Where(seg => includeSegment(seg.xid)).SelectMany(seg => FlattenSegment(seg, xform)));

        private static IEnumerable<KeyValuePair<string, T>> FlattenSegment<T>(this ISegment segment,
            Func<object, T> xform) =>
            segment.Elements.SelectMany(elem => elem.FlattenElement(segment.xid, xform))
                   .Prepend(KVP("", segment.xid, xform, segment));

        private static IEnumerable<KeyValuePair<string, T>> FlattenElement<T>(this IElement element, string prefix,
            Func<object, T> xform) =>
            new[]
            {
                KVP(prefix, element.xid, xform, element)
            };

        private static KeyValuePair<string,T> KVP<T>(string prefix, string key, Func<object,T> xform, object x) =>
            new KeyValuePair<string, T>(NormalizeKey(key, prefix), xform(x));

        private static string NormalizeKey(string key, string prefix)
        {
            if (prefix.Length == 0)
                return key;
            var sb = new StringBuilder(key).Insert(prefix.Length, PathDelimiter);
            var elementNumberIndex = prefix.Length + 1;
            if (sb[elementNumberIndex] == '0')
                sb.Remove(elementNumberIndex, 1);
            return sb.ToString();
        }
    }
}
