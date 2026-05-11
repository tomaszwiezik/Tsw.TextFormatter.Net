
namespace Tsw.TextFormatter.Net.Tables
{
    /// <summary>
    /// Facade class for creating and formatting tables. It hides the internal implementation details and provides a simple API for users 
    /// to create tables with custom formatting and write them to the console or get their string representation.
    /// </summary>
    public class Table
    {
        public Table(IEnumerable<TableColumn> columns)
        {
            _table = new Internal.Table();
            _table.Columns.AddRange(columns.Select(column => column.ToInternalTableColumn()));
        }

        [Obsolete("Use Table(List<TableColumn> columns) constructor and layouts instead.")]
        public Table(
            List<TableColumn> columns,
            int columnSpacing) : this(columns)
        {
            _columnSpacing = columnSpacing;
        }

        private readonly Internal.Table _table;
        private readonly int _columnSpacing = 1;


        public Table AddHeader()
        {
            var columnRow = new Internal.TableRowHeader();
            columnRow.AddRange(_table.Columns.Select(column => new Internal.TableCellText(
                text: column.Text,
                formatting: column.Formatting)));
            _table.Rows.Add(columnRow);
            return this;
        }


        public Table AddRow<T>(T row, ITableRowAdapter<T> rowAdapter)
        {
            _table.Rows.Add(rowAdapter.GetRow(row).ToInternalTableRowContent());
            return this;
        }


        public Table AddRows<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter)
        {
            _table.Rows.AddRange(rows.Select(row => rowAdapter.GetRow(row).ToInternalTableRowContent()));
            return this;
        }


        public Table AddRow(TableRow row)
        {
            _table.Rows.Add(row.ToInternalTableRowContent());
            return this;
        }


        public Table AddRows(IEnumerable<TableRow> rows)
        {
            _table.Rows.AddRange(rows.Select(row => row.ToInternalTableRowContent()));
            return this;
        }


        public Table AddRowSeparator(char separatorChar = '-')
        {
            _table.Rows.Add(new Internal.TableRowSeparator(_table.Columns, separatorChar));
            return this;
        }


        public void WriteToConsole() =>
            WriteToConsole(new TableLayoutTabular(columnSpacing: _columnSpacing));


        public void WriteToConsole(ITableLayout tableLayout)
        {
            foreach (var line in _table.Build(tableLayout.IgnoreHeader, tableLayout.IgnoreRowSeparators))
            {
                foreach (var cell in tableLayout.Format(line))
                {
                    if (cell.Formatting.ForegroundColor.HasValue) Console.ForegroundColor = cell.Formatting.ForegroundColor.Value;
                    if (cell.Formatting.BackgroundColor.HasValue) Console.BackgroundColor = cell.Formatting.BackgroundColor.Value;
                    Console.Write(cell.Text);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }


        public void WriteToConsole<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter) =>
            WriteToConsole<T>(rows, rowAdapter, new TableLayoutTabular(columnSpacing: _columnSpacing));


        public void WriteToConsole<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter, ITableLayout layout)
        {
            AddHeader();
            AddRowSeparator();
            AddRows(rows, rowAdapter);
            WriteToConsole(layout);
        }


        public override string ToString() =>
            ToString(new TableLayoutTabular(columnSpacing: _columnSpacing));


        public string ToString(ITableLayout layout) =>
            string.Join(Environment.NewLine, _table.Build(layout.IgnoreHeader, layout.IgnoreRowSeparators).Select(x => layout.Format(x).ToString()));


        public string ToString<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter)
        {
            AddHeader();
            AddRowSeparator();
            AddRows(rows, rowAdapter);
            return ToString();
        }


        public string ToString<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter, ITableLayout layout)
        {
            AddHeader();
            AddRowSeparator();
            AddRows(rows, rowAdapter);
            return ToString(layout);
        }

    }
}
