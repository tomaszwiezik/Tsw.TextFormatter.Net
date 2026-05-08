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


        public List<TextLine> Build()
        {
            var columnSpacing = new TableCellSpacing();
            var lines = new List<TextLine>();
            var columnWidths = GetMaxColumnWidths();
            foreach (var row in Rows)
            {
                var line = new TextLine();
                for (int i = 0; i < Math.Min(Columns.Count, row.Count); i++)
                {
                    var column = Columns[i];
                    var cell = row[i];
                    if (i > 0)   // do not add spacing before the first column
                    {
                        line.Add(columnSpacing.Format(column, ColumnSpacing));
                    }
                    line.Add(cell.Format(column, columnWidths[i]));
                }
                lines.Add(line);
            }
            return lines;
        }


#warning TODO: Remove the two methods below and implement max column width calculation in TableRowList.Add and AddRange methods.
        private int[] GetMaxColumnWidths()
        {
            var maxColumnWidths = new int[Columns.Count];
            for (int i = 0; i < Columns.Count; i++)
            {
                maxColumnWidths[i] = GetMaxColumnWidth(i);
            }
            return maxColumnWidths;
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
