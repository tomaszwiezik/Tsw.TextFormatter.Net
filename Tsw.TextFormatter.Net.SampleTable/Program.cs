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


            Console.WriteLine("Default table (adapter's formatting applied):");
            new Table(
                columns: [
                    new TableColumn { Text = "Name" },
                    new TableColumn { Text = "Age" },
                    new TableColumn { Text = "City" }
                    ])
                .WriteToConsole(persons, new PersonRowAdapter());
            Console.WriteLine();


            Console.WriteLine("Formatted tables:");
            new Table(
                columns: [
                    new TableColumn { Text = "Name", Alignment = TextAlignment.Left, Width = 10, ForegroundColor = ConsoleColor.Green },
                    new TableColumn { Text = "Age", Alignment = TextAlignment.Right, Width = TextWidth.Auto, CellAlignment = TextAlignment.Right },
                    new TableColumn { Text = "City", Alignment = TextAlignment.Center, Width = 10, CellAlignment = TextAlignment.Center, ForceWidth = true }
                    ],
                columnSpacing: 5)
                .WriteToConsole(persons, new PersonRowAdapter());
            Console.WriteLine();
            new Table(
                columns: [
                    new TableColumn { Text = "Name", Alignment = TextAlignment.Left, Width = 10, ForegroundColor = ConsoleColor.Green },
                    new TableColumn { Text = "Age", Alignment = TextAlignment.Right, Width = TextWidth.Auto, CellAlignment = TextAlignment.Right },
                    new TableColumn { Text = "City", Alignment = TextAlignment.Center, Width = 10, CellAlignment = TextAlignment.Center, ForceWidth = false }
                    ],
                columnSpacing: 5)
                .WriteToConsole(persons, new PersonRowAdapter());
            Console.WriteLine();


            Console.WriteLine("Custom tables:");
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
                .AddRowSeparator(separatorChar: '=')
                .AddRow(total)
                .WriteToConsole();
            Console.WriteLine();


            Console.WriteLine(table.ToString());
            Console.WriteLine();
        }
    }
}
