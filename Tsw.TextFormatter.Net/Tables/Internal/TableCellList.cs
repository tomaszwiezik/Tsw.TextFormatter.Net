namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal class TableCellList : List<TableCell>
    {
        public TableCellList() { }

        public TableCellList(IEnumerable<TableCell> collection) : base(collection) { }

    }
}
