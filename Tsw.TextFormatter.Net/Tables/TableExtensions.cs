using Tsw.TextFormatter.Net.Tables.Internal;

namespace Tsw.TextFormatter.Net.Tables
{
    /// <summary>
    /// Internal class for convertions between facade table components and their internal representations.
    /// It implements all 'dirty' sections of code.
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


        public static Internal.TableRowContent ToInternalTableRowContent(this TableRow row) =>
            new Internal.TableRowContent(row.Select(cell => new Internal.TableCellText(
                text: cell.Text,
                formatting: new TextFormatting
                {
                    Alignment = cell.Alignment,
                    ForegroundColor = cell.ForegroundColor,
                    BackgroundColor = cell.BackgroundColor
                })));


        public static List<TextLine> ToTextLineCollection(this Internal.Table table,
            bool ignoreHeader,
            bool ignoreRowSeparators)
        {
            var lines = new List<TextLine>();
            var columnWidths = table.Columns.Select(column => table.GetMaxColumnContentWidth(column)).ToList();
            foreach (var row in table.Rows)
            {
                if (row is TableRowHeader && ignoreHeader) continue;
                if (row is TableRowSeparator && ignoreRowSeparators) continue;

                var line = new TextLine();
                for (int i = 0; i < Math.Min(table.Columns.Count, row.Cells.Count); i++)
                {
                    var column = table.Columns[i];
                    var cell = row.Cells[i];
                    line.Add(cell.Format(column, columnWidths[i]));
                }
                lines.Add(line);
            }
            return lines;
        }

    }
}
