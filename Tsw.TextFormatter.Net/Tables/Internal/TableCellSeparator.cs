namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal class TableCellSeparator : TableCell
    {
        public TableCellSeparator(char separatorChar)
            : base(string.Empty, new TextFormatting())
        {
            _separatorChar = separatorChar;
        }

        private readonly char _separatorChar;


        public override TextSegment Format(TableColumn column, int maxWidth) =>
            new TextSegment
            {
                Text = new string(_separatorChar, maxWidth),
                Formatting = new TextFormatting()
            };
    }
}
