namespace Tsw.TextFormatter.Net.Tables
{
    public class TableRowSeparator(
        char separatorChar) : TableRow
    {
        public char SeparatorChar { get; } = separatorChar;


        public override TableRow ApplyColumnFormatting(TableColumns columns)
        {
            var row = new TableRow();
            foreach (var column in columns)
            {
                row.Add(new TableCell()
                {
                    Text = new string(SeparatorChar, column.Width)
                });
            }
            return row;
        }

    }
}
