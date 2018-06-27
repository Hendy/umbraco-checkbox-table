using Newtonsoft.Json.Linq;
using Our.Umbraco.CheckboxTable.Models;
using Our.Umbraco.CheckboxTable.PropertyEditors;
using System.Collections.Generic;
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
            return publishedPropertyType.PropertyEditorAlias == CheckboxTablePropertyEditor.PropertyEditorAlias;
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

            /*
                {
                    columns: ['Bronze', 'Silver', 'Gold'],
                    rows: ['Feature 1', 'Feature 2'],
                    cells: [
                        [true, false, false], 
                        [false, false, false]
                    ]
                }
             */

            var json = JObject.Parse((string)source);

            checkboxTable.ColumnLabels = json["columns"].ToObject<string[]>();

            List<CheckboxTableRow> checkboxTableRows = new List<CheckboxTableRow>();

            var rowCounter = 0;

            foreach(var row in json["rows"])
            {
                checkboxTableRows.Add(
                    new CheckboxTableRow()
                    {
                        RowLabel = row.ToString(),
                        Cells = json["cells"][rowCounter].ToObject<bool[]>()
                    });

                rowCounter++;
            }

            checkboxTable.Rows = checkboxTableRows.ToArray();

            return checkboxTable;
        }
    }
}