namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal abstract class TableCell : TextSegment
    {
        public TableCell(
            string text,
            TextFormatting formatting)
            : base(text, formatting)
        { }

        public abstract TextSegment Format(TableColumn column, int maxWidth);
    }
}
