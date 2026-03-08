namespace Tsw.TextFormatter.Net
{
    public static class StringExtensions
    {
        public static string Align(this string text, TextAlignment? alignment, int width)
        {
            if (text.Length > width)
            {
                return text[..width];
            }

            if (alignment == TextAlignment.Left)
            {
                return text.PadRight(width);
            }
            else if (alignment == TextAlignment.Right)
            {
                return text.PadLeft(width);
            }
            else if (alignment == TextAlignment.Center)
            {
                var padding = (width - text.Length);
                if (padding > 0)
                {
                    var leftPadding = padding / 2;
                    var rightPadding = padding - leftPadding;
                    return text.PadLeft(leftPadding + text.Length).PadRight(width);
                }
            }
            return text;
        }

    }
}
