namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal static class CollectionExtensions
    {
        public static TableColumnList ToTableHeader(this IEnumerable<TableColumn> source) => new TableColumnList(source);
        public static TableRowList ToTableRowList(this IEnumerable<TableRow> source) => new TableRowList(source);
    }
}
