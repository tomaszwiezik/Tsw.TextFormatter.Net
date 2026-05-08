namespace Tsw.TextFormatter.Net.Tables.Internal
{
    internal class TableCellText : TableCell
    {
        public TableCellText(string text, TextFormatting formatting)
            : base(text, formatting)
        { }


        public override TextSegment Format(TableColumn column, int maxWidth) =>
            new TextSegment
            {
                Text = column.ForceWidth ? 
                    TextFormatter.AlignText(Text, Formatting.Alignment ?? column.Formatting.Alignment, maxWidth) : 
                    TextFormatter.AlignText(Text, Formatting.Alignment ?? column.Formatting.Alignment, Math.Max(Text.Length, maxWidth)),
                Formatting = new TextFormatting
                {
                    Alignment = Formatting.Alignment ?? column.Formatting.Alignment,
                    ForegroundColor = Formatting.ForegroundColor,
                    BackgroundColor = Formatting.BackgroundColor
                 }
            };

    }
}
