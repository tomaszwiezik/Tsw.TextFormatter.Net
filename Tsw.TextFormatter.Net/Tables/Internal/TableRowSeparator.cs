namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal class TableRowSeparator : TableRow
    {
        public TableRowSeparator(TableColumnList columns, char separatorChar = '-')
        {
            for (int i = 0; i < columns.Count; i++)
            {
                Add(new TableCellSeparator(separatorChar));
            }
        }

    }
}
