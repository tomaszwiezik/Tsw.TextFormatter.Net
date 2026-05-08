using Tsw.TextFormatter.Net.Tables.Internal;

namespace Tsw.TextFormatter.Net.Tables
{
    /// <summary>
    /// Facade class for creating and formatting tables. It hides the internal implementation details and provides a simple API for users 
    /// to create tables with custom formatting and write them to the console or get their string representation.
    /// </summary>
    public class Table
    {
        public Table(
            List<TableColumn> columns,
            int columnSpacing = 1)
        {
            _table = new Internal.Table(columnSpacing);
            _table.Columns.AddRange(columns.Select(column => new Internal.TableColumn(
                text: column.Text,
                formatting: new TextFormatting
                {
                    Alignment = column.Alignment,
                    ForegroundColor = column.ForegroundColor,
                    BackgroundColor = column.BackgroundColor
                },
                cellFormatting: new TextFormatting
                {
                    Alignment = column.CellAlignment,
                    ForegroundColor = null,
                    BackgroundColor = null
                },
                width: column.Width,
                forceWidth: column.ForceWidth)).ToTableHeader());
        }

        private Internal.Table _table;


        private Internal.TableRowContent ToTableContentRow(TableRow row)
        {
            var internalRow = new Internal.TableRowContent();
            internalRow.AddRange(row.Select(cell => new Internal.TableCellText(
                text: cell.Text,
                formatting: new TextFormatting
                {
                    Alignment = cell.Alignment,
                    ForegroundColor = cell.ForegroundColor,
                    BackgroundColor = cell.BackgroundColor
                })));
            return internalRow;
        }


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
            _table.Rows.Add(ToTableContentRow(rowAdapter.GetRow(row)));
            return this;
        }


        public Table AddRows<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter)
        {
            _table.Rows.AddRange(rows.Select(row => ToTableContentRow(rowAdapter.GetRow(row))));
            return this;
        }


        public Table AddRow(TableRow row)
        {
            _table.Rows.Add(ToTableContentRow(row));
            return this;
        }


        public Table AddRows(IEnumerable<TableRow> rows)
        {
            _table.Rows.AddRange(rows.Select(row => ToTableContentRow(row)));
            return this;
        }


        public Table AddRowSeparator(char separatorChar = '-')
        {
            _table.Rows.Add(new Internal.TableRowSeparator(_table.Columns, separatorChar));
            return this;
        }


        public void WriteToConsole()
        {
            foreach (var line in _table.Build())
            {
                foreach (var cell in line)
                {
                    if (cell.Formatting.ForegroundColor.HasValue) Console.ForegroundColor = cell.Formatting.ForegroundColor.Value;
                    if (cell.Formatting.BackgroundColor.HasValue) Console.BackgroundColor = cell.Formatting.BackgroundColor.Value;
                    Console.Write(cell.Text);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        public void WriteToConsole<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter)
        {
            AddHeader();
            AddRowSeparator();
            AddRows(rows, rowAdapter);
            WriteToConsole();
        }


        public override string ToString() =>
            string.Join(Environment.NewLine, _table.Build().Select(x => x.ToString()));


        public string ToString<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter)
        {
            AddHeader();
            AddRowSeparator();
            AddRows(rows, rowAdapter);
            return ToString();
        }

    }
}
