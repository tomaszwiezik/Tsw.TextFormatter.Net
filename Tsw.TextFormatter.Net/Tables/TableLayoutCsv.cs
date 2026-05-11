namespace Tsw.TextFormatter.Net.Tables
{
    public class TableLayoutCsv : ITableLayout
    {
        public TableLayoutCsv(char separator = ',', bool ignoreHeader = false, bool ignoreRowSeparators = true)
        {
            _cellSeparator = new TextSegment(text: separator.ToString());
            IgnoreHeader = ignoreHeader;
            IgnoreRowSeparators = ignoreRowSeparators;
        }

        private readonly TextSegment _cellSeparator;


        public bool IgnoreHeader { get; }

        public bool IgnoreRowSeparators { get; }


        public TextLine Format(TextLine tableRow)
        {
            var formattedRow = new TextLine();

            foreach (var cell in tableRow)
            {
                if (formattedRow.Count > 0)
                {
                    formattedRow.Add(_cellSeparator);
                }
                formattedRow.Add(new TextSegment(text: cell.Text.Trim(), formatting: cell.Formatting));
            }
            return formattedRow;
        }
    }
}
