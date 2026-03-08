namespace Tsw.TextFormatter.Net
{
    public record FormattedText(
        string Text = "",
        TextAlignment? Alignment = null,
        ConsoleColor? ForegroundColor = null,
        ConsoleColor? BackgroundColor = null);
}
