namespace Tsw.TextFormatter.Net.Tables
{
    public class Table
    {
        public Table(
            TableColumns columns,
            int columnSpacing = 1)
        {
            _columns = columns;
            _columnSpacing = new TableColumnSpacing(columnSpacing);
        }

        private readonly TableColumns _columns;
        private readonly TableColumnSpacing _columnSpacing;
        private readonly TableRows _rows = [];   // All displayed rows, including header and separators


        public Table AddHeader()
        {
            var columnRow = new TableRow();
            columnRow.AddRange(_columns.Select(x => new TableCell
            {
                Text = x.Text,
                Alignment = x.Alignment,
                ForegroundColor = x.ForegroundColor,
                BackgroundColor = x.BackgroundColor
            }));
            _rows.Add(columnRow);
            return this;
        }


        public Table AddRow<T>(T row, ITableRowAdapter<T> rowAdapter)
        {
            _rows.Add(rowAdapter.GetRow(row));
            return this;
        }


        public Table AddRows<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter)
        {
            _rows.AddRange(rows.Select(rowAdapter.GetRow));
            return this;
        }


        public Table AddRowSeparator(char separatorChar = '-')
        {
            _rows.Add(new TableRowSeparator(separatorChar));
            return this;
        }


        private List<FormattedLine> Format()
        {
            var formattedColumns = _columns.SetWidth(_rows);
            var formattedRows = _rows.ApplyColumnFormatting(formattedColumns);
            var formattedLines = formattedRows.Select(row => row.GetLine(_columnSpacing)).ToList();
            return formattedLines;
        }



        public void WriteToConsole()
        {
            foreach (var line in Format())
            {
                foreach (var cell in line)
                {
                    if (cell.ForegroundColor.HasValue) Console.ForegroundColor = cell.ForegroundColor.Value;
                    if (cell.BackgroundColor.HasValue) Console.BackgroundColor = cell.BackgroundColor.Value;
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
            string.Join(Environment.NewLine, Format().Select(x => x.ToString()));

        public string ToString<T>(IEnumerable<T> rows, ITableRowAdapter<T> rowAdapter)
        {
            AddHeader();
            AddRowSeparator();
            AddRows(rows, rowAdapter);
            return ToString();
        }

    }
}
