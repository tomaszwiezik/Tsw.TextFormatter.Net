namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal class Table
    {
        /// <summary>
        /// List of columns in the table. The order of columns in this list determines the order of columns in the output.
        /// </summary>
        public TableColumnList Columns { get; } = [];

        /// <summary>
        /// List of rows in the table. This includes all rows that will be displayed, including the header row and any separator rows.
        /// The order of rows in this list determines the order of rows in the output.
        /// </summary>
        public TableRowList Rows { get; } = [];


        public List<TextLine> Build(
            bool ignoreHeader,
            bool ignoreRowSeparators)
        {
            var lines = new List<TextLine>();
            var columnWidths = GetMaxColumnWidths();
            foreach (var row in Rows)
            {
                if (row is TableRowHeader && ignoreHeader) continue;
                if (row is TableRowSeparator && ignoreRowSeparators) continue;

                var line = new TextLine();
                for (int i = 0; i < Math.Min(Columns.Count, row.Count); i++)
                {
                    var column = Columns[i];
                    var cell = row[i];
                    line.Add(cell.Format(column, columnWidths[i]));
                }
                lines.Add(line);
            }
            return lines;
        }


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
