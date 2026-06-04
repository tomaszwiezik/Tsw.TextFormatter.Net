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


        /// <summary>
        /// Calculates max column width based on the content of the cells in the column.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public int GetMaxColumnContentWidth(TableColumn column)
        {
            if (column.Width == TextWidth.Auto)
            {
                var columnIndex = Columns.IndexOf(column);
                return Rows
                    .FindAll(row => columnIndex < row.Cells.Count)
                    .Select(row => row.Cells.ElementAt(columnIndex).Text.Length)
                    .DefaultIfEmpty(0)
                    .Max();
            }
            else
            {
                return column.Width;
            }
        }

    }
}
