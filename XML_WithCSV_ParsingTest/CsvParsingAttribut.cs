using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_WithCSV_ParsingTest
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class CsvParsingAttribut : Attribute
    {
        private int number;

        public CsvParsingAttribut(int number)
        {
            this.number = number;
        }
        public virtual int Number { get { return this.number; } }
    }
}
