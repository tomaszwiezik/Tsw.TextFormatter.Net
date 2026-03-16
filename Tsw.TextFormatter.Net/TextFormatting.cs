namespace Tsw.TextFormatter.Net
{
    public record TextFormatting(
        TextAlignment? Alignment = null,
        ConsoleColor? ForegroundColor = null,
        ConsoleColor? BackgroundColor = null
        );
}
