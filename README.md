# Introduction

Plain text formatting library for text files and command-line utilities. Supported formats:
* Table (tabular, CSV)


## Tables

Data presented in tabular form. The displayed layout depends on the used layout provider.


### Defining a table

A default table consists of columns, row separator and rows. The following code snippet shows how to define a three-column default table:
```cs
var table = new Table(
    columns: [
        new TableColumn { Text = "Name" },
        new TableColumn { Text = "Age" },
        new TableColumn { Text = "City" }
        ]);
```

Each column can be customized by setting the following properties:
* `Text` (default: empty text) - column header text
* `TextAlignment` (default: `TextAlignment.Center`) - column header text alignment, one of: 
	* TextAlignment.Left
	* TextAlignment.Center
	* TextAlignment.Right
	* TextAlignment.Justify
* `Width` (default: `TextWidth.Auto`) - column width, can be set to `TextWidth.Auto` to automatically adjust to the longest cell in the column
* `ForceWidth` (default: true) - if set to true and the column has a fixed width, then the column will be truncated if the cell text is longer than the column width; if set to false, the column will not be truncated and will expand to fit the longest cell text
* `ForegroundColor` (default: not defined) - column header text color
* `BackgroundColor` (default: not defined) - column header background color
* `CellAlignment` (default: not defined) - cell text alignment


### Populating a table

Rows can be added to the table in one of the following ways:
* Directly, by adding `TableRow` record(s), each consisting of `TableCell` records
* By using `ITableRowAdapter` to convert any collection to `TableRow` records

Every `TableCell` can use its own formatting, which overrides the column formatting for that cell:
* `Text` (default: empty text) - cell text
* `TextAlignment` (default: not defined, derived from column) - column header text alignment
* `ForegroundColor` (default: not defined, derived from column) - cell text color
* `BackgroundColor` (default: not defined, derived from column) - cell background color

Both populating methods are available for all functions that add rows to the table, such as `AddRow()`, `AddRows()`, `WriteToConsole()` and `ToString()`.

Example 1 - Adding a single row directly:
```cs
var table = new Table(...);
table.AddRow(new TableRow
{
	new TableCell { Text = "Alice" },
	new TableCell { Text = "30" },
	new TableCell { Text = "New York" }
});
```

Example 2 - Adding rows using `ITableRowAdapter`:
```cs
// A list:
List<Person> persons = [
	new Person(Name: "Alice", Age: 30, City: "New York"),
	new Person(Name: "Bob", Age: 25, City:"Los Angeles"),
	new Person(Name: "Charlie", Age: 999, City: "Chicago")
];

// A sample adapter for persons list
internal class PersonRowAdapter : ITableRowAdapter<Person>
{
	public TableRow GetRow(Person row) => [
		new TableCell { Text = row.Name },
		new TableCell { Text = row.Age.ToString() },
		new TableCell { Text = row.City }
	];
}

var table = new Table(...);
table.AddRow(persons, new PersonRowAdapter());
```


### Table layouts

Layouts determine how the table is rendered. The library supports the following layouts:
* Tabular: `TableLayoutTabular(int columnSpacing = 1)` - the default layout, which renders the table in a tabular format with columns and rows
* CSV: `TableLayoutCsv(char separator = ',', bool ignoreHeader = false, bool ignoreRowSeparators = true)` - renders the table in a CSV format, with columns separated by a specified character (default: comma)

It is also possible to define a custom layout by implementing the `ITableLayout` interface.

Example: Rendering a table in CSV format, using semicolon separator instead of the default comma:
```cs
new Table(
    columns: [
        new TableColumn { Text = "Name" },
        new TableColumn { Text = "Age" },
        new TableColumn { Text = "City" }
        ])
	.WriteToConsole(persons, new PersonRowAdapter(), new TableLayoutCsv(separator: ';'));
```


### Displaying a table with formatting

To display the table to the console with formatting, use one of the `WriteToConsole()` methods:
* `WriteToConsole()` - displays the table with formatting, using the default layout
* `WriteToConsole(ITableLayout tableLayout)` - displays the table with formatting, using the specified layout
* `WriteToConsole(IEnumerable<TableRow> rows)` - displays the specified rows with formatting, using the default layout
* `WriteToConsole(IEnumerable<TableRow> rows, ITableLayout tableLayout)` - displays the specified rows with formatting, using the specified layout
* `WriteToConsole<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter)` - displays the specified rows of type T with formatting, using the default layout and the specified row adapter
* `WriteToConsole<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter, ITableLayout tableLayout)` - displays the specified rows of type T with formatting, using the specified layout and the specified row adapter

Examples below use the sample `PersonRowAdapter` defined in the previous section.

Example 1 - Displaying a default table with formatting:
```cs
new Table(
    columns: [
        new TableColumn { Text = "Name" },
        new TableColumn { Text = "Age" },
        new TableColumn { Text = "City" }
        ])
	.WriteToConsole(persons, new PersonRowAdapter());
```


### Customizing a table

By default, a table consists of column row, a row separator and data rows. However, it is possible to customize the table by adding or removing these elements,
as well as by adding custom rows, such as a total row. Do do so, all table components must be added manually, before the table is rendered. The following methods 
are available for customizing the table:
* `AddHeader()` - adds a header row to the table, using the column definitions
* `AddRow<T>(T row, ITableRowAdapter<T> rowAdapter)` - adds a row of type T to the table, using the specified row adapter
* `AddRows<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter)` - adds rows of type T to the table, using the specified row adapter
* `AddRow(TableRow row)` - adds a row to the table
* `AddRows(IEnumerable<TableRow> rows)` - adds rows to the table
* `AddRowSeparator(char separatorChar = '-')` - adds a row separator to the table, using the specified character (default: '-')

Example: Render a table with a header, a row separator and a separated total row:
```cs
var table = new Table(
    columns: [
        new TableColumn { Text = "Name" },
        new TableColumn { Text = "Age" },
        new TableColumn { Text = "City" }
        ]);
table
	.AddHeader()
	.AddRowSeparator()
	.AddRows(persons, new PersonRowAdapter())
	.AddRowSeparator(separatorChar: '=')
	.AddRow(new TableRow
	{
		new TableCell { Text = "Total age", ForegroundColor = ConsoleColor.Red, Alignment = TextAlignment.Right },
		new TableCell { Text = persons.Select(x => x.Age).Sum().ToString(), ForegroundColor = ConsoleColor.Red, Alignment = TextAlignment.Right },
	})
	.WriteToConsole();
```


### Converting a table to text

When it is needed to have the table as a text, for example to write it to a file, the `ToString()` method can be used. The method has the following overloads:
* `ToString()` - returns a text representation of the table, using the default layout
* `ToString(ITableLayout layout)` - returns a text representation of the table, using the specified layout
* `ToString(IEnumerable<TableRow> rows)` - returns a text representation of the specified rows, using the default layout
* `ToString(IEnumerable<TableRow> rows, ITableLayout tableLayout)` - returns a text representation of the specified rows, using the specified layout
* `ToString<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter)` - returns a text representation of the specified rows of type T, using the default layout and the specified row adapter
* `ToString<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter, ITableLayout tableLayout)` - returns a text representation of the specified rows of type T, using the specified layout and the specified row adapter

> [!NOTE]
> All `ToString()` methods return a multi-line text representation of the table. Color specifiers are ignored.
