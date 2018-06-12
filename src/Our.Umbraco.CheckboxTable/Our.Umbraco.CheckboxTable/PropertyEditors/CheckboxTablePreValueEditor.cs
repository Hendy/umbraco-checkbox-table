using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.CheckboxTable.PropertyEditors
{
    internal class CheckboxTablePreValueEditor : PreValueEditor
    {
        [PreValueField("columns", "Columns", "number", Description = "Number of columns")]
        public int Columns { get; set; } // stacked content uses strings ?

        [PreValueField("rows", "Rows", "number", Description = "Number of rows")]
        public int Rows { get; set; }
    }
}
