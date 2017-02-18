
using System.Xml.Serialization;

namespace XML_WithCSV_ParsingTest
{
    [XmlRoot("Data")]
    public class CustomSerialization:ParserBase
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
