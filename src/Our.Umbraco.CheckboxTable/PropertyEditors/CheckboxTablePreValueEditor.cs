using System;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.CheckboxTable.PropertyEditors
{
    internal class CheckboxTablePreValueEditor : PreValueEditor
    {
        /// <summary>
        /// Renders a fully featured checkbox table, which is used for the default editor state
        /// </summary>
        [PreValueField(
            "defaultCheckboxTable", 
            "Default Checkbox Table", 
            "/App_Plugins/CheckboxTable/CheckboxTableConfig.html",
            Description = "The default editor state for the checkbox table")]
        public string DefaultCheckboxTable { get; set; }

        /// <summary>
        /// When true, the content editor can edit the default column labels
        /// </summary>
        [PreValueField(
            "defaultColumnLabelsEditable",
            "Default Column Labels Editable",
            "boolean",
            Description = "When checked, the content editor can edit the default column labels")]
        public bool DefaultColumnLabelsEditable { get; set; }

        /// <summary>
        /// When true, the content editor can edit the default row labels
        /// </summary>
        [PreValueField(
            "defaultRowLabelsEditable",
            "Default Row Labels Editable",
            "boolean",
            Description = "When checked, the content editor can edit the default row labels")]
        public bool DefaultRowLabelsEditable { get; set; }

        /// <summary>
        /// When true, the content editor can check/uncheck the default cells
        /// </summary>
        [PreValueField(
            "defaultCellsEditable",
            "Default Cells Editable",
            "boolean",
            Description = "When checked, the content editor can check/uncheck the default cells")]
        public bool DefaultCellsEditable { get; set; }

        /// <summary>
        /// When true, the content editor can add and remove columns
        /// </summary>
        [PreValueField(
            "addRemoveNewColumns", 
            "Add/Remove New Columns", 
            "boolean", 
            Description = "When checked, the content editor can add and remove new columns")]
        public bool AddRemoveNewColumns { get; set; }

        /// <summary>
        /// When true, the content editor can add and remove rows
        /// </summary>
        [PreValueField(
            "addRemoveNewRows", 
            "Add/Remove New Rows", 
            "boolean", 
            Description = "When checked, the content editor can add and remove new rows")]
        public bool AddRemoveNewRows { get; set; }


        [Obsolete]
        [PreValueField("columns", "Columns", "number", Description = "Number of columns")]
        public int Columns { get; set; } // stacked content uses strings ?

        [Obsolete]
        [PreValueField("rows", "Rows", "number", Description = "Number of rows")]
        public int Rows { get; set; }
    }
}
