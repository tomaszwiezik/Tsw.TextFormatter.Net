namespace Tsw.TextFormatter.Net.Tables.Internal
{
    /// <summary>
    /// A table column definition.
    /// </summary>
    internal class TableColumn: TextSegment
    {
        /// <summary>
        /// Initializes a new instance of the TableColumn class with the specified header text, formatting, cell
        /// formatting, width, and width enforcement option.
        /// </summary>
        /// <param name="text">The text to display in the column header.</param>
        /// <param name="formatting">The formatting to apply to the column header text.</param>
        /// <param name="cellFormatting">The formatting to apply to the content of each cell in the column.</param>
        /// <param name="width">The preferred width of the column, in characters. Must be greater than zero.</param>
        /// <param name="forceWidth">true to enforce the specified width exactly; otherwise, false to allow automatic adjustment.</param>
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

        /// <summary>
        /// If true, column width is enforced for all cells in the column by padding shorter content and truncating longer content to fit the specified width.
        /// If false, the column width will be determined by the longest cell content in the column and shorter content will still be padded.
        /// </summary>
        public bool ForceWidth { get; init; }
    }
}
