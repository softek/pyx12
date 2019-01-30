using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Xml;
using System.Xml.Serialization;
using X12ResourceTool.Spec;

namespace X12ResourceTool
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var filename in args)
            {
                var shortFileName = Path.GetFileName(filename);
                Console.WriteLine($"-------------------------------- {shortFileName} ----------------------------------");
                var tx = DeserializeTransaction(filename);
                foreach (var row in X12SpecConversion.Flatten(tx, x => ((x as IName)?.name, (x as IUsage)?.Usage)))
                    Console.WriteLine(row);
                WriteResxFile($"{filename}.Name.resx",
                    tx.Flatten(x => (x as IName)?.name));
                WriteResxFile($"{filename}.Usage.resx",
                    tx.Flatten(x => (x as IUsage)?.Usage));
            }
        }

        private static void WriteResxFile(string resxFileName, IEnumerable<KeyValuePair<string, string>> values)
        {
            using (var oWriter = new ResXResourceWriter(resxFileName))
            {
                foreach(var value in values)    
                    oWriter.AddResource(value.Key, value.Value);
                oWriter.Generate();
                oWriter.Close();
            }
        }

        static ITransaction DeserializeTransaction(string fileName) =>
            (ITransaction) DeserializeFile(fileName);

        static object DeserializeFile(string fileName) =>
            new XmlSerializer(InferDocumentType(fileName)).Deserialize(File.OpenRead(fileName));

        private static Type InferDocumentType(string fileName)
        {
            var doc = new XmlDocument();
            doc.Load(fileName);
            switch (doc.DocumentElement.Attributes["xsi:noNamespaceSchemaLocation"]?.Value)
            {
                case "map.v2.xsd": return typeof(Spec.MapV2.transactionType);
                case "map.xsd": return typeof(Spec.MapV1.transactionType);
                default:
                    Console.Error.WriteLine($"XSD is not specified in {fileName}");
                    return typeof(Spec.MapV1.transactionType);
            }
        }
    }
}
