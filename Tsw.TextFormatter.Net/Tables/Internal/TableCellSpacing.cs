namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal class TableCellSpacing : TableCell
    {
        public TableCellSpacing()
            : base(string.Empty, formatting: new TextFormatting())
        { }


        public override TextSegment Format(TableColumn column, int maxWidth) =>
            new TextSegment
            {
                Text = new string(' ', maxWidth),
                Formatting = Formatting
            };

    }
}