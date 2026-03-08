using Tsw.TextFormatter.Net.Tables;

namespace Tsw.TextFormatter.Net.Tests
{
    public class TableColumnUnitTest
    {
        [Fact]
        public void TestDefaultInitialization()
        {
            var column = new TableColumn();

            Assert.Equal(string.Empty, column.Text);
            Assert.Equal(TextAlignment.Center, column.Alignment);
            Assert.Equal(TextWidth.Auto, column.Width);
            Assert.Equal(TextAlignment.Left, column.CellAlignment);
            Assert.Null(column.ForegroundColor);
            Assert.Null(column.BackgroundColor);
        }

        [Fact]
        public void TestCustomInitialization()
        {
            var column = new TableColumn(
                Text: "test",
                Alignment: TextAlignment.Left,
                Width: 5,
                CellAlignment: TextAlignment.Right,
                ForegroundColor: ConsoleColor.Red,
                BackgroundColor: ConsoleColor.Green);

            Assert.Equal("test", column.Text);
            Assert.Equal(TextAlignment.Left, column.Alignment);
            Assert.Equal(5, column.Width);
            Assert.Equal(TextAlignment.Right, column.CellAlignment);
            Assert.Equal(ConsoleColor.Red, column.ForegroundColor);
            Assert.Equal(ConsoleColor.Green, column.BackgroundColor);
        }

    }
}
