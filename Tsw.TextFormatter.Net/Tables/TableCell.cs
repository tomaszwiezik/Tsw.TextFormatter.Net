namespace Tsw.TextFormatter.Net.Tables
{
    /// <summary>
    /// Table cell content and formatting.
    /// </summary>
    /// <param name="Text">The text.</param>
    /// <param name="Alignment">Text alignmwnt.</param>
    /// <param name="ForegroundColor">Text foreground color.</param>
    /// <param name="BackgroundColor">Text background color.</param>
    public record TableCell(
        string Text = "",
        TextAlignment? Alignment = null,
        ConsoleColor? ForegroundColor = null,
        ConsoleColor? BackgroundColor = null)
        : FormattedText(
            Text, Alignment, ForegroundColor, BackgroundColor);
}
