using Tsw.TextFormatter.Net.Tables;

namespace Tsw.TextFormatter.Net
{
    public static class CollectionExtensions
    {
        public static void AddIf<T>(this List<T> list, bool condition, T element)
        {
            if (condition)
            {
                list.Add(element);
            }
        }

        public static TableRows ToTableRows(this IEnumerable<TableRow> source) => new TableRows(source);
        public static TableRow ToTableRow(this IEnumerable<TableCell> source) => new TableRow(source);
        public static TableColumns ToTableColumns(this IEnumerable<TableColumn> source) => new TableColumns(source);
    }
}
