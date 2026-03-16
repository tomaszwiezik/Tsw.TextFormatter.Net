namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal class Table
    {
        public Table(
            int columnSpacing)
        {
            Columns = new TableColumnList();
            Rows = new TableRowList();
            ColumnSpacing = columnSpacing;
        }

        /// <summary>
        /// List of columns in the table. The order of columns in this list determines the order of columns in the output.
        /// </summary>
        public TableColumnList Columns { get; }

        /// <summary>
        /// List of rows in the table. This includes all rows that will be displayed, including the header row and any separator rows.
        /// The order of rows in this list determines the order of rows in the output.
        /// </summary>
        public TableRowList Rows { get; }

        /// <summary>
        /// Gets the number of spaces between columns.
        /// </summary>
        public int ColumnSpacing { get; }


        public List<TextLine> Format()
        {
            var columnSpacing = new TableCellSpacing();
            var lines = new List<TextLine>();
            foreach (var row in Rows)
            {
                var line = new TextLine();
                for (int i = 0; i < Columns.Count; i++)
                {
                    var column = Columns[i];
                    if (i < row.Count)
                    {
                        var cell = row[i];
                        if (i > 0)
                        {
                            line.Add(columnSpacing.Format(column, ColumnSpacing));
                        }
                        line.Add(cell.Format(column, GetMaxColumnWidth(i)));
                    }
                }
                lines.Add(line);
            }
            return lines;
        }

        private int GetMaxColumnWidth(int columnIndex)
        {
            var column = Columns[columnIndex];
            if (column.Width != TextWidth.Auto)
            {
                return column.Width;
            }
            return Rows
                .FindAll(row => columnIndex < row.Count)
                .Select(row => row.ElementAt(columnIndex).Text.Length)
                .DefaultIfEmpty(0)
                .Max();
        }

    }
}
