# Introduction

Plain text formatting library for text files and command-line utilities. Supported formats:
* Table


## Tables

Rows presented in tabular form, which can be added to the table in one of the following ways:
* Directly, by adding `TableRow` records
* By using `ITableRowAdapter` to convert lists to `TableRow` records

Once populated with data, a table can be displayed to the console:
```cs
var table = new Table(
	columns: [...],
	columnSpacing: 5)
	
// Display fully formatted table, including colors:
table.WriteToConsole();

// Display/get a text representaion of a table (colors are not included):
var tableText = table.ToString();
Console.WriteLine(tableText);
```


### `ITableRowAdapter` interface

`ITableRowAdapter` interface is a simple per-row converter of any type to `TableRow`:

```cs
namespace Tsw.TextFormatter.Net.Tables
{
    /// <summary>
    /// Table row adapter interface to convert a row of type T to a TableRow.
    /// The adapter is neccessary for the table to be able to convert a custom type to a format that can be rendered.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITableRowAdapter<T>
    {
        /// <summary>
        /// Transforms an object of custom type T to a TableRow that can be rendered by the table.
        /// </summary>
        /// <param name="row">The object to transform.</param>
        /// <returns></returns>
        TableRow GetRow(T row);
    }
}
```

Sample usage:
```cs
// A list:
List<Person> persons = [
	new Person(Name: "Alice", Age: 30, City: "New York"),
	new Person(Name: "Bob", Age: 25, City:"Los Angeles"),
	new Person(Name: "Charlie", Age: 999, City: "Chicago")
];

// A sample adapter for persons list, conditional formatting added:
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
```


### Default table

A default table is costructed of columns, line separator and rows.

```cs
List<Person> persons = [
	new Person(Name: "Alice", Age: 30, City: "New York"),
	new Person(Name: "Bob", Age: 25, City:"Los Angeles"),
	new Person(Name: "Charlie", Age: 999, City: "Chicago")
];

new Table(
	columns: [
		new TableColumn { Text = "Name", Alignment = TextAlignment.Left, Width = 10, ForegroundColor = ConsoleColor.Green },
		new TableColumn { Text = "Age", Alignment = TextAlignment.Right, Width = TextWidth.Auto, CellAlignment = TextAlignment.Right },
		new TableColumn { Text = "City", Alignment = TextAlignment.Center, Width = 20, CellAlignment = TextAlignment.Center }
		],
	columnSpacing: 5)
	.WriteToConsole(persons, new PersonRowAdapter());
```

Column definition properties:
* `Text` - column header text
* `Alignment` - column header text alignment, `TextAlignment.Center` is the default value
* `Width` - column width, can be set to `TextWidth.Auto` to automatically adjust to the longest cell in the column, `TextWidth.Auto` is the default value
* `ForceWidth` - true by default; if set to true and the column has a fixed width, then the column will be truncated if the cell text is longer than the column width; if set to false, the column will not be truncated and will expand to fit the longest cell text
* `ForegroundColor` - column header text color, not defined by default
* `BackgroundColor` - column header background color, not defined by default
* `CellAlignment` - cell text alignment, if not set, it will be the same as `Alignment`


### Custom table

A table style can be customized.

```cs
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
	columnSpacing: 3)
	.AddHeader()
	.AddRowSeparator()
	.AddRows(persons, new PersonRowAdapter())
	.AddRowSeparator(separatorChar: '=')
	.AddRow(total)
	.WriteToConsole();
```
