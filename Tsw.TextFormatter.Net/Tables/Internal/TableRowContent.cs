namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal class TableRowContent : TableRow
    {
        public TableRowContent() { }

        public TableRowContent(IEnumerable<TableCell> cells) : base(cells) { }
    }
}
