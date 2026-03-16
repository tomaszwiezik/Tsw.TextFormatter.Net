namespace Tsw.TextFormatter.Net
{
    public static class TextFormatter
    {
        /// <summary>
        /// Align the text to the max width based on the specified alignment. If the text is longer than the max width, it will be truncated.
        /// </summary>
        /// <param name="text">The text to align.</param>
        /// <param name="alignment">Aignment. If null is provided, then no alignment is applied.</param>
        /// <param name="maxWidth">Tha max width of the text after formatting.</param>
        /// <returns>Returns the aligned text.</returns>
        public static string AlignText(string text, TextAlignment? alignment, int maxWidth)
        {
            if (text.Length > maxWidth)
            {
                return text[..maxWidth];
            }
            else if (alignment == TextAlignment.Left)
            {
                return text.PadRight(maxWidth);
            }
            else if (alignment == TextAlignment.Right)
            {
                return text.PadLeft(maxWidth);
            }
            else if (alignment == TextAlignment.Center)
            {
                var padding = (maxWidth - text.Length);
                var leftPadding = padding / 2;
                var rightPadding = padding - leftPadding;
                return text.PadLeft(leftPadding + text.Length).PadRight(maxWidth);
            }
            else if (alignment == TextAlignment.Justify)
            {
                var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var justifiedText = string.Empty;
                var textLength = words.Sum(w => w.Length);
                decimal spacesNeeded = maxWidth - textLength;
                int spacesUsed = 0;
                for (var i = 0; i < words.Length; i++)
                {
                    var spacesToAdd = Convert.ToInt32(i * (spacesNeeded / (words.Length - 1))) - spacesUsed;
                    justifiedText += new string(' ', spacesToAdd);
                    justifiedText += words[i];
                    spacesUsed += spacesToAdd;
                }
                return justifiedText;
            }
            return text;
        }

        public static TextSegment Format(TextSegment textSegment, int maxWidth) =>
            new TextSegment(
                text: AlignText(textSegment.Text, textSegment.Formatting.Alignment, maxWidth),
                formatting: textSegment.Formatting);
    }
}
