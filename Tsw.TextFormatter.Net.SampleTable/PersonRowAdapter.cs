using Tsw.TextFormatter.Net.Tables;

namespace Tsw.TextFormatter.Net.SampleTable
{
    internal class PersonRowAdapter : ITableRowAdapter<Person>
    {
        public TableRow GetRow(Person row) => [
            new TableCell
            {
                Text = row.Name,
                Alignment = row.Name == "Bob" ? TextAlignment.Right : TextAlignment.Left
            },
            new TableCell
            {
                Text = row.Age.ToString(),
                BackgroundColor = ConsoleColor.DarkGray
            },
            new TableCell
            {
                Text = row.City,
                ForegroundColor = ConsoleColor.Red
            }];
    }
}
