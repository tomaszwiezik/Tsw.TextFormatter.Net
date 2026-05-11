namespace Tsw.TextFormatter.Net.Tables
{
    public class TableRow : List<TableCell>
    {
        public TableRow() { }
        public TableRow(IEnumerable<TableCell> collection) : base(collection) { }
    }
}
