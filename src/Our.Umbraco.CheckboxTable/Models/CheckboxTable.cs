namespace Our.Umbraco.CheckboxTable.Models
{
    /// <summary>
    /// Model for the Checkbox Table property editor
    /// </summary>
    public class CheckboxTable
    {
        /// <summary>
        /// Collection of collumn labels (the first empty th cell is not in this collection)
        /// </summary>
        public string[] ColumnLabels { get; set; }

        /// <summary>
        /// Collection of rows (the first row of column labels is not in this collection)
        /// </summary>
        public CheckboxTableRow[] Rows { get; set; }
    }
}
