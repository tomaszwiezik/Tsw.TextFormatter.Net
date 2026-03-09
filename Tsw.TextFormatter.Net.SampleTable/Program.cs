using Tsw.TextFormatter.Net.Tables;

namespace Tsw.TextFormatter.Net.SampleTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = [
                new Person(Name: "Alice", Age: 30, City: "New York"),
                new Person(Name: "Bob", Age: 25, City:"Los Angeles"),
                new Person(Name: "Charlie", Age: 999, City: "Chicago")
            ];
            var total = new TableRow
            {
                new TableCell { Text = "Total age", ForegroundColor = ConsoleColor.Red, Alignment = TextAlignment.Right },
                new TableCell { Text = persons.Select(x => x.Age).Sum().ToString(), ForegroundColor = ConsoleColor.Red, Alignment = TextAlignment.Right },
            };


            new Table(
                columns: [
                    new TableColumn { Text = "Name", Alignment = TextAlignment.Left, Width = 10, ForegroundColor = ConsoleColor.Green },
                    new TableColumn { Text = "Age", Alignment = TextAlignment.Right, Width = TextWidth.Auto, CellAlignment = TextAlignment.Right },
                    new TableColumn { Text = "City", Alignment = TextAlignment.Center, Width = 20, CellAlignment = TextAlignment.Center }
                    ],
                columnSpacing: 5)
                .WriteToConsole(persons, new PersonRowAdapter());



            var table = new Table(
                columns: [
                    new TableColumn { Text = "Name", Alignment = TextAlignment.Left, Width = 10, ForegroundColor = ConsoleColor.Green },
                    new TableColumn { Text = "Age", Alignment = TextAlignment.Right, Width = TextWidth.Auto, CellAlignment = TextAlignment.Right },
                    new TableColumn { Text = "City", Alignment = TextAlignment.Center, Width = 20, CellAlignment = TextAlignment.Center }
                    ],
                columnSpacing: 3);
            table
                .AddHeader()
                .AddRowSeparator()
                .AddRows(persons, new PersonRowAdapter())
                .AddRowSeparator()
                .AddRow(total)
                .WriteToConsole();

            Console.WriteLine();
            Console.WriteLine(table.ToString());
        }
    }
}
