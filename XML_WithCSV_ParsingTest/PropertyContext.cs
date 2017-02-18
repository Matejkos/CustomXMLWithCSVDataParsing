using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XML_WithCSV_ParsingTest
{
    class PropertyContext
    {
        public Type TypeData { get; set; }
        public int ColumnNumber { get; set; }
        public string PropertyName { get; set; }
        public PropertyInfo PropInfo { get; set; }
    }


}
