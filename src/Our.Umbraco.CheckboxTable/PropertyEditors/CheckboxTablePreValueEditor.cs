using System;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.CheckboxTable.PropertyEditors
{
    internal class CheckboxTablePreValueEditor : PreValueEditor
    {
        /// <summary>
        /// The full set of config options (for 1 view & 1 controller)
        /// </summary>
        [PreValueField(
            "checkboxTable", 
            "", 
            "/App_Plugins/CheckboxTable/CheckboxTableConfig.html",
            Description = "", 
            HideLabel = true)]
        public string CheckboxTable { get; set; }

        [Obsolete]
        [PreValueField("columns", "Columns", "number", Description = "OBSOLETE")]
        public int Columns { get; set; } // stacked content uses strings ?

        [Obsolete]
        [PreValueField("rows", "Rows", "number", Description = "OBSOLETE")]
        public int Rows { get; set; }
    }
}
