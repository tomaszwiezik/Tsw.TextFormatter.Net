namespace Tsw.TextFormatter.Net.Tables
{
    public class TableRows : List<TableRow>
    {
        public TableRows() { }
        public TableRows(IEnumerable<TableRow> collection) : base(collection) { }

        public TableRows ApplyColumnFormatting(TableColumns columns) =>
            this.Select(row => row.ApplyColumnFormatting(columns)).ToTableRows();

    }
}
