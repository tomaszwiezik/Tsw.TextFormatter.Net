namespace Tsw.TextFormatter.Net.Tables
{
    public record TableColumnSpacing(
        int Spacing)
        : FormattedText(
            Text: "".PadLeft(Spacing));
}
