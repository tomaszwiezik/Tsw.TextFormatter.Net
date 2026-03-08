namespace Tsw.TextFormatter.Net.Tables
{
    public class TableRow : List<TableCell>
    {
        public TableRow() { }
        public TableRow(IEnumerable<TableCell> collection) : base(collection) { }


        public FormattedLine GetLine(TableColumnSpacing columnSpacing)
        {
            var line = new FormattedLine();
            foreach (var cell in this)
            {
                line.AddIf(line.Count > 0, columnSpacing);
                line.Add(cell);
            }
            return line;
        }


        public virtual TableRow ApplyColumnFormatting(TableColumns columns)
        {
            var formattedRow = new TableRow();
            var columnIndex = 0;
            foreach (var cell in this)
            {
                var column = columns.ElementAt(columnIndex);
                formattedRow.Add(new TableCell()
                {
                    Text = cell.Text.Align(cell.Alignment ?? column.CellAlignment, column.Width),
                    Alignment = cell.Alignment ?? column.CellAlignment,
                    ForegroundColor = cell.ForegroundColor,
                    BackgroundColor = cell.BackgroundColor
                });
                columnIndex++;
            }
            return formattedRow;
        }
    }
}
