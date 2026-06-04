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
            if (maxWidth < 0) throw new ArgumentException($"Argument maxWidth has a negative value");

            if (alignment == null)
            {
                return text.PadRight(maxWidth)[..maxWidth];
            }
            else if (alignment == TextAlignment.Left)
            {
                return text.Trim().PadRight(maxWidth)[..maxWidth];
            }
            else if (alignment == TextAlignment.Right)
            {
                text = text.Trim().PadLeft(maxWidth);
                return text[(text.Length - maxWidth)..];
            }
            else if (alignment == TextAlignment.Center)
            {
                text = text.Trim();
                var leftPadding = (maxWidth - text.Length) / 2;
                return text.PadLeft(leftPadding + text.Length).PadRight(maxWidth)[..maxWidth];
            }
            else if (alignment == TextAlignment.Justify)
            {
                var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var justifiedText = string.Empty;
                var totalWordsLength = words.Sum(w => w.Length);
                decimal spacesPerGap = maxWidth - totalWordsLength;
                if (words.Length > 1)
                {
                    spacesPerGap /= (words.Length - 1);
                }
                if (spacesPerGap < 0)
                {
                    spacesPerGap = 1;
                }
                int spacesUsed = 0;
                for (var i = 0; i < words.Length; i++)
                {
                    var spacesToAdd = Convert.ToInt32(i * spacesPerGap) - spacesUsed;
                    justifiedText += new string(' ', spacesToAdd);
                    justifiedText += words[i];
                    spacesUsed += spacesToAdd;
                }
                return justifiedText.PadRight(maxWidth)[..maxWidth];
            }
            return text;
        }

    }
}
