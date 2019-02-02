using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;

namespace X12ResourceTool
{
    public class ResourceWriters
    {
        public static Action<string, IEnumerable<KeyValuePair<string, string>>> ForExtension(string extension) =>
            ByExtension.ContainsKey(extension)
                ? ByExtension[extension]
                : throw new NotImplementedException("Unknown extension: " + extension);

        public static Dictionary<string, Action<string,IEnumerable<KeyValuePair<string, string>>>> ByExtension =
            new Dictionary<string, Action<string, IEnumerable<KeyValuePair<string, string>>>>(StringComparer.InvariantCultureIgnoreCase)
            {
                {".resx",    WriteResxFile},
                {".restext", WriteRestextFile},
                {".txt",     WriteRestextFile},
            };

        public static void WriteResxFile(string filename, IEnumerable<KeyValuePair<string, string>> values)
        {
            var fi = new FileInfo(filename);
            if (fi.Exists)
                fi.Delete();
            using (var oWriter = new ResXResourceWriter(filename))
            {
                foreach (var value in values.OrderBy(Key))
                    oWriter.AddResource(value.Key, value.Value);
                oWriter.Generate();
                oWriter.Close();
            }
        }

        public static void WriteRestextFile(string filename, IEnumerable<KeyValuePair<string, string>> values) =>
            File.WriteAllLines(filename, values.Select(res => $"{res.Key}={res.Value}"));

        private static TKey Key<TKey, TVal>(KeyValuePair<TKey, TVal> kvp) => kvp.Key;
    }
}
