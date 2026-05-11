namespace Tsw.TextFormatter.Net.Tables
{
    /// <summary>
    /// Internal class for converting facade table components into their internal representations.
    /// </summary>
    internal static class TableExtensions
    {
        public static Internal.TableColumn ToInternalTableColumn(this TableColumn column) =>
            new Internal.TableColumn(
                text: column.Text,
                formatting: new TextFormatting
                {
                    Alignment = column.Alignment,
                    ForegroundColor = column.ForegroundColor,
                    BackgroundColor = column.BackgroundColor
                },
                cellFormatting: new TextFormatting
                {
                    Alignment = column.CellAlignment,
                    ForegroundColor = null,
                    BackgroundColor = null
                },
                width: column.Width,
                forceWidth: column.ForceWidth);

        //public static Internal.TableRowContent ToInternalTableRowContent(this TableRow row)
        //{
        //    var internalRow = new Internal.TableRowContent();
        //    internalRow.AddRange(row.Select(cell => new Internal.TableCellText(
        //        text: cell.Text,
        //        formatting: new TextFormatting
        //        {
        //            Alignment = cell.Alignment,
        //            ForegroundColor = cell.ForegroundColor,
        //            BackgroundColor = cell.BackgroundColor
        //        })));
        //    return internalRow;
        //}

        public static Internal.TableRowContent ToInternalTableRowContent(this TableRow row) =>
            new Internal.TableRowContent(row.Select(cell => new Internal.TableCellText(
                text: cell.Text,
                formatting: new TextFormatting
                {
                    Alignment = cell.Alignment,
                    ForegroundColor = cell.ForegroundColor,
                    BackgroundColor = cell.BackgroundColor
                })));


        //public static T ToInternalTableRow<T>(this TableRow row) where T : Internal.TableRow, new()
        //{
        //    var internalRow = new T();
        //    internalRow.AddRange(row.Select(cell => new Internal.TableCellText(
        //        text: cell.Text,
        //        formatting: new TextFormatting
        //        {
        //            Alignment = cell.Alignment,
        //            ForegroundColor = cell.ForegroundColor,
        //            BackgroundColor = cell.BackgroundColor
        //        })));
        //    return internalRow;
        //}
    }
}
