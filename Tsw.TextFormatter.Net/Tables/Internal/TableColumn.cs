namespace Tsw.TextFormatter.Net.Tables.Internal
{
    /// <summary>
    /// A table column definition.
    /// </summary>
    internal class TableColumn: TextSegment
    {
        public TableColumn(
            string text,
            TextFormatting formatting,
            TextFormatting cellFormatting,
            int width,
            bool forceWidth)
            : base(text, formatting)
        {
            CellFormatting = cellFormatting;
            Width = width;
            ForceWidth = forceWidth;
        }

        /// <summary>
        /// Default formatting for the column's cells. This is used when a cell doesn't have its own formatting specified.
        /// </summary>
        public TextFormatting CellFormatting { get; init; }

        /// <summary>
        /// Max column width. If the content exceeds this width, it will be truncated. If the content is shorter, it will be padded according to the alignment.
        /// </summary>
        public int Width { get; init; }

        public bool ForceWidth { get; init; }
    }
}
