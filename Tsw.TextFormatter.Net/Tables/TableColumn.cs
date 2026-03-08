namespace Tsw.TextFormatter.Net.Tables
{
    public record TableColumn(
        string Text = "",
        TextAlignment? Alignment = TextAlignment.Center,
        ConsoleColor? ForegroundColor = null,
        ConsoleColor? BackgroundColor = null,
        int Width = TextWidth.Auto,
        TextAlignment? CellAlignment = TextAlignment.Left)
        : FormattedText(
            Text, Alignment, ForegroundColor, BackgroundColor);
}
