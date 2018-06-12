namespace Our.Umbraco.CheckboxTable.Models
{
    /// <summary>
    /// Represents a row in a checkbox table (but not the column heading row)
    /// </summary>
    public class CheckboxTableRow
    {
        /// <summary>
        /// The first cell in a row is the row label
        /// </summary>
        public string RowLabel { get; set; }

        /// <summary>
        /// All cells (except the row label) are boolean flags (as respresented in the cms by checkboxes)
        /// </summary>
        public bool[] Cells { get; set; }
    }
}
