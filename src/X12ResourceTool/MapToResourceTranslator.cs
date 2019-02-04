using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using X12ResourceTool.Spec;

namespace X12ResourceTool
{
    using Selector = Func<IEnumerable<string>,string>;
    using ResourceFileWriter = Action<string, IEnumerable<KeyValuePair<string, string>>>;

    /// <summary>
    /// Builds X12 segment/field name resource files from XML maps,
    /// and a .CS file containing attributes that specify applicability of each resource file.
    /// </summary>
    public static class MapToResourceTranslator
    {
        public static IEnumerable<string> ReferencedMapFiles(string mapsXmlFileName) =>
            ReferencedMapFiles(((MapsType)DeserializeFile(mapsXmlFileName)).version);

        public static IEnumerable<string> ReferencedMapFiles(IEnumerable<VersionType> versions) =>
            versions
                .SelectMany(version =>
                    version.map.Select(map => map.Value))
                .Distinct();

        public static void CreateResourcesAndApplicabilityAttributes(
            IEnumerable<string> fileNames,
            string outputDirectory, string resourcesFileExtension,
            Selector nameSelector, Selector usageSelector,
            ResourceFileWriter writeResourcesFile)
        {
            string RelativeInputFile(string name) => Path.Combine(fileNames.Select(Path.GetDirectoryName).FirstOrDefault(), name);
            string RelativeOutputFile(string name) => Path.Combine(outputDirectory, name);

            void SaveResources(string name, string description, Selector selector, IEnumerable<KeyValuePair<string, string>> resources)
            {
                var fileName = RelativeOutputFile(name + resourcesFileExtension);
                writeResourcesFile(fileName, WithSourceAndCopyright(BestDefaults(resources, selector), description));
                Log($"Wrote resources to {fileName}");
            }

            string GetName(object name) => (name as IName)?.name;
            string GetUsage(object usage) => (usage as IUsage)?.Usage;

            var allNames = new List<KeyValuePair<string, string>>();
            var allUsage = new List<KeyValuePair<string, string>>();
            var segmentsByFile = new Dictionary<string, string>();

            foreach (var filename in fileNames)
            {
                var shortFileName = Path.GetFileName(filename) ?? "";
                // Generic control map, without specific transaction support.
                var isControl = shortFileName.StartsWith("x12.");
                // Exclude control segments from transaction maps (because they are redundant).
                var includeSegment = isControl
                    ? new Func<string, bool> (ControlSegments.Contains)
                    : segmentName => !ControlSegments.Contains(segmentName);

                Console.WriteLine($"-------------------------------- {shortFileName} ----------------------------------");
                var tx = DeserializeTransaction(filename);
                foreach (var row in tx.GetResources(x => (GetName(x), GetUsage(x)), includeSegment))
                    Console.WriteLine(row);

                var names = tx.GetResources(GetName, includeSegment);
                var usage = tx.GetResources(GetUsage, includeSegment);

                SaveResources($"{shortFileName}.Name",  shortFileName, nameSelector,  names);
                SaveResources($"{shortFileName}.Usage", shortFileName, usageSelector, usage);

                allNames.AddRange(names);
                allUsage.AddRange(usage);
                segmentsByFile.Add(shortFileName, UniqueSegmentsCsv(names.Select(kvp => kvp.Key)));
            }

            const string x12Default = "x12.default";

            SaveResources($"{x12Default}.Name", "Defaults via " + nameSelector.Method.Name, nameSelector, allNames);
            SaveResources($"{x12Default}.Usage", "Defaults via " + usageSelector.Method.Name, usageSelector, allUsage);
            segmentsByFile.Add(x12Default, UniqueSegmentsCsv(allNames.Select(kvp => kvp.Key)));
            var defaultMap = new VersionType
            {
                icvn = "",
                map = new[]
                {
                    new VersionTypeMap {abbr = "", fic = "", tspc = "", vriic = "", Value = x12Default},
                }
            };

            SaveMapsCs(
                RelativeInputFile("maps.xml"),
                RelativeOutputFile("Maps.cs"),
                defaultMap,
                segmentName => segmentsByFile[segmentName]);
        }

        private static readonly HashSet<string> ControlSegments = new HashSet<string>(new [] {"GS","GE","ISA","IEA","TA1"});

        private static IReadOnlyList<KeyValuePair<string, string>> BestDefaults(
            IEnumerable<KeyValuePair<string, string>> resources,
            Func<IEnumerable<string>, string> selector)
        {
            return resources
                   .GroupBy(resource => resource.Key, resource => resource.Value)
                   .Select(g =>
                       new KeyValuePair<string, string>(
                           g.Key,
                           selector(g.GroupBy(rg => rg).OrderByDescending(rg => rg.Count()).Select(Key))))
                   .ToList();
        }

        private static void SaveMapsCs(string mapsXmlFileName, string csFileName, VersionType appendedVersion,
            Func<string,string> segmentCsvForMapFile)
        {
            var maps = (MapsType) DeserializeFile(mapsXmlFileName);

            var versions = maps.version;

            SaveMapsCs(csFileName, versions.Concat(new []{appendedVersion}), segmentCsvForMapFile);
        }

        private static void SaveMapsCs(string csFileName, IEnumerable<VersionType> versions,
            Func<string,string> segmentCsvForMapFile)
        {
            string Literal(string s) =>
                s == null
                    ? "null"
                    : $"@\"{s.Replace("\"", "\"\"")}\"";

            var mapTuples = versions
                .SelectMany(version =>
                    version.map.Select(map =>
                        (version.icvn, map.vriic, map.fic, map.tspc, map.abbr, map: map.Value,
                         segmentsCsv: segmentCsvForMapFile(map.Value))));
            var sb = new StringBuilder()
                     .AppendLine($"// Generated by pyx12 X12ResourceTool {typeof(Program).Assembly.GetName().Version}.")
                     .AppendLine();

            foreach (var m in mapTuples)
                sb.AppendLine(
                    $"[assembly: X12ResourceTool.Map(icvn={Literal(m.icvn)}, vriic={Literal(m.vriic)}, fic={Literal(m.fic)}, tspc={Literal(m.tspc)}, abbr={Literal(m.abbr)}, map={Literal(m.map)}, segmentsCsv={Literal(m.segmentsCsv)})]");

            sb.AppendLine().AppendLine().AppendLine(GetMapAttributeCs());

            File.WriteAllText(csFileName, sb.ToString());
            Log($"Wrote map applicability attributes to {csFileName}");
        }

        private static string GetMapAttributeCs()
        {
            const string mapAttributeCs = "X12ResourceTool.MapAttribute.cs";
            using (var rdr =
                new StreamReader(
                    typeof(Program).Assembly.GetManifestResourceStream(mapAttributeCs)
                    ?? throw new InvalidOperationException($"Missing resource: {mapAttributeCs}")))
            {
                return rdr.ReadToEnd();
            }
        }

        private static IEnumerable<KeyValuePair<string, string>> WithSourceAndCopyright(
            IReadOnlyList<KeyValuePair<string, string>> values, string source) =>
            new[]
                {
                    new KeyValuePair<string, string>("_Source", source),
                    new KeyValuePair<string, string>("_Text_Copyright", Pyx12Copyright),
                }
                .Concat(values);

        private static string UniqueSegmentsCsv(IEnumerable<string> paths) =>
            string.Join(",",
                new SortedSet<string>(
                    paths.Where(p => p.IndexOf(X12SpecConversion.PathDelimiter) < 0)));


        private static ITransaction DeserializeTransaction(string fileName) =>
            (ITransaction) DeserializeFile(fileName);

        private static object DeserializeFile(string fileName) =>
            new XmlSerializer(InferDocumentType(fileName)).Deserialize(File.OpenRead(fileName));

        private static Type InferDocumentType(string fileName)
        {
            var doc = new XmlDocument();
            doc.Load(fileName);
            switch (doc.DocumentElement?.Name)
            {
                case "transaction": return InferTransactionMapType(doc.DocumentElement);
                case "maps": return typeof(MapsType);
                default: throw new NotImplementedException(
                    $"XML Element type not supported: {doc.DocumentElement?.Name} in {fileName}");
            }
        }

        private static Type InferTransactionMapType(XmlElement documentElement)
        {
            switch (documentElement.Attributes["xsi:noNamespaceSchemaLocation"]?.Value)
            {
                case "map.v2.xsd": return typeof(Spec.MapV2.transactionType);
                case "map.xsd": return typeof(Spec.MapV1.transactionType);
                default:
                    return typeof(Spec.MapV1.transactionType);
            }
        }

        private static TKey Key<TKey, TVal>(IGrouping<TKey, TVal> kvp) => kvp.Key;

        internal static Action<string> Log = Console.Error.WriteLine;

        private const string Pyx12Copyright =
            "Copyright (c) John Holland <john@zoner.org>.  All rights reserved.  This software is licensed as described in the file https://github.com/azoner/pyx12/blob/master/LICENSE.txt, which you should have received as part of this distribution.";
    }
}
