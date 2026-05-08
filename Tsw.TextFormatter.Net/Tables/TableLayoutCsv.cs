namespace Tsw.TextFormatter.Net.Tables
{
    public class TableLayoutCsv : ITableLayout
    {
        public TableLayoutCsv(char separator = ',', bool ignoreSeparators = true)
        {
            _cellSeparator = new TextSegment(text: separator.ToString());
            IgnoreSeparators = ignoreSeparators;
        }

        private readonly TextSegment _cellSeparator;


        public bool IgnoreSeparators { get; }


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
