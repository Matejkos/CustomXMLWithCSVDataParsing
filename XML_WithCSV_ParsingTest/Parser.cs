using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace XML_WithCSV_ParsingTest
{
    class Parser
    {
        Dictionary<int, PropertyContext> ColumnInformation = new Dictionary<int, PropertyContext>();
        public Parser()
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
    }
}
