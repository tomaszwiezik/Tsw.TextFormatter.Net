namespace Tsw.TextFormatter.Net
{
    /// <summary>
    /// A portion of text with a specific formatting.
    /// </summary>
    public class TextSegment
    {
        public TextSegment()
            : this(string.Empty, new TextFormatting())
        { }

        public TextSegment(
            string text)
            : this(text, new TextFormatting())
        { }

        public TextSegment(
            string text,
            TextFormatting formatting)
        {
            Text = text;
            Formatting = formatting;
        }


        /// <summary>
        /// The text content of the segment.
        /// </summary>
        public string Text { get; init; }

        /// <summary>
        /// The text formattting.
        /// </summary>
        public TextFormatting Formatting { get; init; }
    }
}
