using Tsw.TextFormatter.Net.Tables;

namespace Tsw.TextFormatter.Net.SampleTable
{
    internal class TotalRowAdapter : ITableRowAdapter<Total>
    {
        public TableRow GetRow(Total row) => new TableRow()
        {
            new TableCell()
            {
                Text = row.Caption,
                Alignment = TextAlignment.Right
            },
            new TableCell()
            {
                Text = row.TotalAge.ToString(),
                Alignment = TextAlignment.Right
            }
        };
    }
}
