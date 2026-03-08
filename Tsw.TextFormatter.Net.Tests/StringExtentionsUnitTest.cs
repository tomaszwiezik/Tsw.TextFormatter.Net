namespace Tsw.TextFormatter.Net.Tests
{
    public class StringExtentionsUnitTest
    {
        [Fact]
        public void TestAlignment()
        {
            var width = 7;
            var textShorterThanWidth = "1234";
            Assert.Equal("1234   ", textShorterThanWidth.Align(TextAlignment.Left, width: width));
            Assert.Equal("   1234", textShorterThanWidth.Align(TextAlignment.Right, width: width));
            Assert.Equal(" 1234  ", textShorterThanWidth.Align(TextAlignment.Center, width: width));

            var textAsLongAsWidth = "1234567";
            Assert.Equal("1234567", textAsLongAsWidth.Align(TextAlignment.Left, width: width));
            Assert.Equal("1234567", textAsLongAsWidth.Align(TextAlignment.Right, width: width));
            Assert.Equal("1234567", textAsLongAsWidth.Align(TextAlignment.Center, width: width));

            var textLongerThanWidth = "123456789";
            Assert.Equal("1234567", textLongerThanWidth.Align(TextAlignment.Left, width: width));
            Assert.Equal("1234567", textLongerThanWidth.Align(TextAlignment.Right, width: width));
            Assert.Equal("1234567", textLongerThanWidth.Align(TextAlignment.Center, width: width));
        }

    }
}
