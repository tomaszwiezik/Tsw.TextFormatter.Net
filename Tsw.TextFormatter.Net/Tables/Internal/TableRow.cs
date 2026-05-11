namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal abstract class TableRow : List<TableCell>
    {
        public TableRow() { }

        public TableRow(IEnumerable<TableCell> cells) : base(cells) { }
    }
}
