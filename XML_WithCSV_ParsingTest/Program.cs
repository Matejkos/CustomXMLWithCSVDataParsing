using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_WithCSV_ParsingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new CustomSerializationBase();
            parser.Deserialize("12,13,dane");
            Console.ReadLine();
        }
    }
}
