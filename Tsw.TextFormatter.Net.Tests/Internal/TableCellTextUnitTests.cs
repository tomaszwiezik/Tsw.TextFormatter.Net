using Tsw.TextFormatter.Net.Tables.Internal;

namespace Tsw.TextFormatter.Net.Tests.Internal
{
    public class TableCellTextUnitTests
    {
        private TextFormatting GetAlignmentFormatting(TextAlignment alignment) => new TextFormatting
        {
            Alignment = alignment
        };
        private TableColumn GetColumn(TextAlignment cellAlignment, int width, bool forceWidth) => new TableColumn(
            text: string.Empty,
            formatting: new TextFormatting(),
            cellFormatting: GetAlignmentFormatting(cellAlignment),
            width,
            forceWidth);
        private TextSegment FormatCell(string text, TextAlignment cellAlignment, int width, bool forceWidth) =>
            new TableCellText(
                text: text,
                formatting: GetAlignmentFormatting(cellAlignment))
            .Format(
                column: GetColumn(cellAlignment: cellAlignment, width: width, forceWidth: forceWidth),
                maxWidth: width);


        [Fact]
        public void TestFormat()
        {
            var widthGreaterThanTextLength = 14;
            Assert.Equal("Hello World   ", FormatCell("Hello World", TextAlignment.Left, width: widthGreaterThanTextLength, forceWidth: true).Text);
            Assert.Equal("   Hello World", FormatCell("Hello World", TextAlignment.Right, width: widthGreaterThanTextLength, forceWidth: true).Text);
            Assert.Equal(" Hello World  ", FormatCell("Hello World", TextAlignment.Center, width: widthGreaterThanTextLength, forceWidth: true).Text);
            Assert.Equal("Hello    World", FormatCell("Hello World", TextAlignment.Justify, width: widthGreaterThanTextLength, forceWidth: true).Text);

            Assert.Equal("Hello World   ", FormatCell("Hello World", TextAlignment.Left, width: widthGreaterThanTextLength, forceWidth: false).Text);
            Assert.Equal("   Hello World", FormatCell("Hello World", TextAlignment.Right, width: widthGreaterThanTextLength, forceWidth: false).Text);
            Assert.Equal(" Hello World  ", FormatCell("Hello World", TextAlignment.Center, width: widthGreaterThanTextLength, forceWidth: false).Text);
            Assert.Equal("Hello    World", FormatCell("Hello World", TextAlignment.Justify, width: widthGreaterThanTextLength, forceWidth: false).Text);

            var widthSmallerThanTextLength = 5;
            Assert.Equal("Hello", FormatCell("Hello World", TextAlignment.Left, width: widthSmallerThanTextLength, forceWidth: true).Text);
            Assert.Equal("Hello", FormatCell("Hello World", TextAlignment.Right, width: widthSmallerThanTextLength, forceWidth: true).Text);
            Assert.Equal("Hello", FormatCell("Hello World", TextAlignment.Center, width: widthSmallerThanTextLength, forceWidth: true).Text);
            Assert.Equal("Hello", FormatCell("Hello World", TextAlignment.Justify, width: widthSmallerThanTextLength, forceWidth: true).Text);

            Assert.Equal("Hello World", FormatCell("Hello World", TextAlignment.Left, width: widthSmallerThanTextLength, forceWidth: false).Text);
            Assert.Equal("Hello World", FormatCell("Hello World", TextAlignment.Right, width: widthSmallerThanTextLength, forceWidth: false).Text);
            Assert.Equal("Hello World", FormatCell("Hello World", TextAlignment.Center, width: widthSmallerThanTextLength, forceWidth: false).Text);
            Assert.Equal("Hello World", FormatCell("Hello World", TextAlignment.Justify, width: widthSmallerThanTextLength, forceWidth: false).Text);
        }
    }
}
