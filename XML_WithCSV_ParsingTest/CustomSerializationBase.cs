using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_WithCSV_ParsingTest
{
    class CustomSerializationBase:Parser
    {
        [CsvParsingAttribut(1)]
        public int Column1 { get;  set;}

        [CsvParsingAttribut(2)]
        public int Column2 { get; set; }

        [CsvParsingAttribut(3)]
        public string Column3 { get; set; }

        public string Column4 { get; set; }
    }
}
