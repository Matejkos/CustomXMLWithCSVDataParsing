using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Text;

namespace XML_WithCSV_ParsingTest
{
    public abstract class ParserBase : IXmlSerializable
    {
        Dictionary<int, PropertyContext> ColumnInformation = new Dictionary<int, PropertyContext>();
        public ParserBase()
        {
            foreach (var prop in this.GetType().GetProperties())
            {

                Console.WriteLine(prop.Name);
                foreach (var attr in prop.GetCustomAttributes(false))
                {
                    var atr = attr as CsvParsingAttribut;
                    if (atr != null)
                    {
                        ColumnInformation[atr.Number] = new PropertyContext() {ColumnNumber= atr.Number, PropertyName =prop.Name, TypeData= prop.PropertyType, PropInfo= prop };
                    }
                }
            }
        }

        public void Deserialize(string input)
        {
            string[] data = input.Split(',');

            if (data.Length >= ColumnInformation.Keys.Max())
            {
                var typCon = new TypeConverter();
                foreach (var row in ColumnInformation)
                {
                    row.Value.PropInfo.SetValue(this, TypeDescriptor.GetConverter(row.Value.TypeData).ConvertFromString(data[row.Key - 1]));
                }
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public virtual void ReadXml(XmlReader reader)
        {
            this.Deserialize(reader.ReadElementContentAsString().Trim());
        }

        public virtual void WriteXml(XmlWriter writer)
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0;i< ColumnInformation.Keys.Max();i++)
            {
                builder.Append(ColumnInformation[i + 1].PropInfo.GetValue(this)).Append(",");
            }
            writer.WriteString(builder.ToString());
        }
    }
}
