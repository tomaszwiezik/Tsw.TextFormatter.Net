namespace Tsw.TextFormatter.Net.Tests
{
    public class FormattedLineUnitTests
    {
        [Fact]
        public void TestToString()
        {
            var formattedLine = new FormattedLine
            {
                new FormattedText { Text = "Hello" },
                new FormattedText { Text = "World" }
            };
            Assert.Equal("HelloWorld", formattedLine.ToString());
        }
    }
}
