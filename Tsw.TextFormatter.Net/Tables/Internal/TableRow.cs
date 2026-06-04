namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal abstract class TableRow
    {
        public TableRow() { }

        public TableRow(IEnumerable<TableCell> cells)
        {
            Cells.AddRange(cells);
        }


        /// <summary>
        /// A list of row cells.
        /// </summary>
        public TableCellList Cells { get; } = [];
    }
}
