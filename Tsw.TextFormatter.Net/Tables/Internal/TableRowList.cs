namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal class TableRowList : List<TableRow>
    {
        public TableRowList() { }
        public TableRowList(IEnumerable<TableRow> collection) : base(collection) { }
    }
}
