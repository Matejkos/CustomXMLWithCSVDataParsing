using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XML_WithCSV_ParsingTest
{
    class Program
    {
        private const string testData = @"
                <Data>
                    1,2,test
                </Data>
";
        static void Main(string[] args)
        {
            var xmlSerializer = new XmlSerializer(typeof(CustomSerialization));
            CustomSerialization data = (CustomSerialization)xmlSerializer.Deserialize(new StringReader(testData));
            MemoryStream stream = new MemoryStream();
            xmlSerializer.Serialize(stream, data);
            stream.Seek(0, SeekOrigin.Begin);
            StreamReader reader = new StreamReader(stream);
            Console.WriteLine(reader.ReadToEnd());
            Console.ReadLine();
        }
    }
}
