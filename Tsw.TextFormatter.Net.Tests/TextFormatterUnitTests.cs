namespace Tsw.TextFormatter.Net.Tests
{
    public class TextFormatterUnitTests
    {
        [Fact]
        public void TestAlignTextOfAShortText()
        {
            var textToalign = "Hello World";   // 11 characters
            var maxWidth = 14;

            Assert.Equal(textToalign, TextFormatter.AlignText(textToalign, null, maxWidth));
            Assert.Equal($"{textToalign}   ", TextFormatter.AlignText(textToalign, TextAlignment.Left, maxWidth));
            Assert.Equal($"   {textToalign}", TextFormatter.AlignText(textToalign, TextAlignment.Right, maxWidth));
            Assert.Equal($" {textToalign}  ", TextFormatter.AlignText(textToalign, TextAlignment.Center, maxWidth));
            Assert.Equal("Hello    World", TextFormatter.AlignText(textToalign, TextAlignment.Justify, maxWidth));
        }

        [Fact]
        public void TestAlignTextOfALongText()
        {
            var textToalign = "Hello World again!";   // 18 characters
            var maxWidth = 14;

            Assert.Equal(textToalign.Substring(0, maxWidth), TextFormatter.AlignText(textToalign, null, maxWidth));
            Assert.Equal(textToalign.Substring(0, maxWidth), TextFormatter.AlignText(textToalign, TextAlignment.Left, maxWidth));
            Assert.Equal(textToalign.Substring(0, maxWidth), TextFormatter.AlignText(textToalign, TextAlignment.Right, maxWidth));
            Assert.Equal(textToalign.Substring(0, maxWidth), TextFormatter.AlignText(textToalign, TextAlignment.Center, maxWidth));
            Assert.Equal(textToalign.Substring(0, maxWidth), TextFormatter.AlignText(textToalign, TextAlignment.Justify, maxWidth));
        }

        [Fact]
        public void TestTextJustification()
        {
            var textToalign = "Hello World again and again";   // 27 characters
            string formattedText;

            formattedText = TextFormatter.AlignText(textToalign, TextAlignment.Justify, 10);
            Assert.Equal("Hello Worl", formattedText);
            Assert.Equal(10, formattedText.Length);

            formattedText = TextFormatter.AlignText(textToalign, TextAlignment.Justify, 28);
            Assert.Equal("Hello World again  and again", formattedText);
            Assert.Equal(28, formattedText.Length);

            formattedText = TextFormatter.AlignText(textToalign, TextAlignment.Justify, 40);
            Assert.Equal("Hello    World    again     and    again", formattedText);
            Assert.Equal(40, formattedText.Length);
        }

    }
}
