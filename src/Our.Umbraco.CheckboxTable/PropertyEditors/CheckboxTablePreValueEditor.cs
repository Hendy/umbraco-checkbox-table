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
            "defaultCheckboxTable", 
            "Default Checkbox Table", 
            "/App_Plugins/CheckboxTable/CheckboxTable.html",
            Description = "Set the default columns and rows")]
        public string DefaultCheckboxTable { get; set; }

        [PreValueField(
            "columnPermissions", 
            "Column Permissions", 
            "/App_Plugins/CheckboxTable/CheckboxTablePermissions.html",
            Description = "Ccontent editor permissions for the column axis")]
        public string ColumnPermissions { get; set; }

        [PreValueField(
            "rowPermissions", 
            "Row Permissions",
            "/App_Plugins/CheckboxTable/CheckboxTablePermissions.html",
            Description = "Content editor permissions for the row axis")]
        public string RowPermissions { get; set; }

        [Obsolete]
        [PreValueField("columns", "Columns", "number", Description = "OBSOLETE")]
        public int Columns { get; set; } // stacked content uses strings ?

        [Obsolete]
        [PreValueField("rows", "Rows", "number", Description = "OBSOLETE")]
        public int Rows { get; set; }
    }
}
