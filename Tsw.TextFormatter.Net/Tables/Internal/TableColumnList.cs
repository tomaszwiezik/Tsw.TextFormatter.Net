namespace Tsw.TextFormatter.Net.Tables.Internal
{
    /// <summary>
    /// A list of table columns. This is used by the Table class to store the column definitions.
    /// </summary>
    internal class TableColumnList : List<TableColumn>
    {
        public TableColumnList() { }

        public TableColumnList(IEnumerable<TableColumn> collection) : base(collection) { }

    }
}
