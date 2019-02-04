using System;
using System.IO;
using System.Linq;

namespace X12ResourceTool
{
    /// <summary>
    /// Builds X12 segment/field name resource files from XML maps,
    /// and a .CS file containing attributes that specify applicability of each resource file.
    /// </summary>
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (!args.Any())
            {
                Usage();
                return 1;
            }

            try
            {
                CreateResourcesAndApplicabilityAttributes(
                    ReadReferencedMapFilesFromMapsXml(args[0]),
                    GetEnvironmentSetting);
                return 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                return 2;
            }
        }

        private static void Usage()
        {
            Console.WriteLine(@"Usage: X12ResourceTool path\to\maps.xml");
            Console.WriteLine();
            Console.WriteLine("When there are several values for a key, these environment variables are used to make a choice.");
            Console.WriteLine("Each may set to one selector.");
            Console.WriteLine($"set {Setting.Name_choice}={string.Join("|", ResourceFormatting.Selector.Keys)}");
            Console.WriteLine($"set {Setting.Usage_choice}={string.Join("|", ResourceFormatting.Selector.Keys)}");
            Console.WriteLine();
            Console.WriteLine("Supported output formats:");
            Console.WriteLine($"set {Setting.Resource_Extension}={string.Join("|", ResourceWriters.ByExtension.Keys)}");
            Console.WriteLine();
            Console.WriteLine("Output directory:");
            Console.WriteLine($"set {Setting.Output_Directory}={string.Join("|", ResourceWriters.ByExtension.Keys)}");
        }

        private static string GetEnvironmentSetting(Setting key, string @default) =>
            Environment.GetEnvironmentVariable(key.ToString()) ?? @default;

        public static string[] ReadReferencedMapFilesFromMapsXml(string mapsXmlFileName)
        {
            var dir = Path.GetDirectoryName(mapsXmlFileName);

            string RelativePath(string fileName) =>
                Path.Combine(dir, fileName);

            return MapToResourceTranslator.ReferencedMapFiles(mapsXmlFileName)
                .OrderBy(s => s.ToLowerInvariant())
                .Select(RelativePath)
                .ToArray();
        }

        public static void CreateResourcesAndApplicabilityAttributes(string[] fileNames, Func<Setting, string, string> setting)
        {
            MapToResourceTranslator.CreateResourcesAndApplicabilityAttributes(
                fileNames,
                nameSelector: ResourceFormatting.Selector[setting(Setting.Name_choice, "OnlyOrUncertain")],
                usageSelector: ResourceFormatting.Selector[setting(Setting.Usage_choice, "First")],
                outputDirectory: setting(Setting.Output_Directory, Path.GetDirectoryName(fileNames[0]) ?? ""),
                resourcesFileExtension: setting(Setting.Resource_Extension, ".restext"),
                writeResourcesFile: ResourceWriters.ForExtension(setting(Setting.Resource_Extension, ".restext")));
        }
    }
}
