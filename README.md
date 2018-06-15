# Umbraco Checkbox Table
Property editor for a table with editable row/column labels and toggleable cells.


## Property Editor

![Property Editor Example](docs/PropertyEditor.png)
    

## Property Editor Configuration

![Property Editor Configuration Example](docs/PropertyEditorConfiguration.png)


## Model Rendering

    @{
        // model (as would be set)
        Our.Umbraco.CheckboxTable.Models.CheckboxTable checkboxTable; 
    }

    <table>
        <tr>
            <th></th> <!-- irrelevant cell -->
            @foreach (var columnLabel in checkboxTable.ColumnLabels)
            {
                <th>@columnLabel</th>
            }
        </tr>
        @foreach (var row in checkboxTable.Rows)
        {
            <tr>
                <td>@row.RowLabel</td>
                @foreach (var cell in row.Cells)
                {
                    <td>@(cell ? "X" : "")</td>
                }
            </tr>
        }
    </table>
