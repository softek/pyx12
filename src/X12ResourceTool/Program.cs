using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace X12ResourceTool
{
    class Program
    {
        //static object DeserializeFile(string fileName)=>
            
        static void Main(string[] args)
        {
            foreach (var transaction in args.Select(File.OpenRead).Select(new XmlSerializer(typeof(Spec.MapV1.transactionType)).Deserialize))
                transaction.ToString();

        }
    }
}
