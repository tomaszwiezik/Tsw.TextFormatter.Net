namespace Tsw.TextFormatter.Net.Tables
{
    public class TableLayoutTabular : ITableLayout
    {
        public TableLayoutTabular(int columnSpacing = 1)
        {
            _cellSpacing = new TextSegment(text: new string(' ', columnSpacing));
        }

        private readonly TextSegment _cellSpacing;


        public bool IgnoreHeader => false;

        public bool IgnoreRowSeparators => false;


        public TextLine Format(TextLine tableRow)
        {
            var formattedRow = new TextLine();

            foreach (var cell in tableRow)
            {
                if (formattedRow.Count > 0)
                {
                    formattedRow.Add(_cellSpacing);
                }
                formattedRow.Add(cell);
            }
            return formattedRow;
        }
    }
}
