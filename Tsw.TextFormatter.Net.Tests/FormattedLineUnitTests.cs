namespace Tsw.TextFormatter.Net.Tests
{
    public class FormattedLineUnitTests
    {
        [Fact]
        public void TestToString()
        {
            var formattedLine = new TextLine
            {
                new TextSegment { Text = "Hello" },
                new TextSegment { Text = "World" }
            };
            Assert.Equal("HelloWorld", formattedLine.ToString());
        }
    }
}
