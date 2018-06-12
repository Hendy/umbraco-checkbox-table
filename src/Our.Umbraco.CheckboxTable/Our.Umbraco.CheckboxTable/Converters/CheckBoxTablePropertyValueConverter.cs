using Newtonsoft.Json.Linq;
using Our.Umbraco.CheckboxTable.Models;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.CheckboxTable.Converters
{
    [PropertyValueType(typeof(Models.CheckboxTable))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Content)]
    public class CheckBoxTablePropertyValueConverter : PropertyValueConverterBase
    {
        /// <summary>
        /// Check to see if this property value converter should take effect for the supplied published property type
        /// </summary>
        /// <param name="publishedPropertyType"></param>
        /// <returns></returns>
        public override bool IsConverter(PublishedPropertyType publishedPropertyType)
        {
            return publishedPropertyType.PropertyEditorAlias == "checkboxTable";
        }

        /// <summary>
        /// Convert the saved json into a strongly typed model
        /// </summary>
        /// <param name="publishedPropertyType"></param>
        /// <param name="source">The saved json from the Checkbox table property editor</param>
        /// <param name="preview"></param>
        /// <returns>A <see cref="CheckboxTable"/> object</returns>
        public override object ConvertSourceToObject(PublishedPropertyType publishedPropertyType, object source, bool preview)
        {
            var checkboxTable = new Models.CheckboxTable();

            var rows = JArray.Parse((string)source);

            checkboxTable.ColumnLabels = rows.First().Skip(1).Select(x => x.ToString()).ToArray();

            List<CheckboxTableRow> checkboxTableRows = new List<CheckboxTableRow>();

            foreach (var row in rows.Skip(1))
            {
                checkboxTableRows.Add(new CheckboxTableRow()
                {
                    RowLabel = row.First().ToString(),
                    Cells = row.Skip(1).Select(x => (bool)x).ToArray()
                });
            }

            checkboxTable.Rows = checkboxTableRows.ToArray();

            return checkboxTable;
        }
    }
}
