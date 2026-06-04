namespace Tsw.TextFormatter.Net.Tests
{
    public class TextFormatterUnitTests
    {
        [Fact]
        public void TestAlignTextNone()
        {
            var text = " Hello World ";

            Assert.Equal(" Hello W", TextFormatter.AlignText(text, null, text.Length - 5));
            Assert.Equal(" Hello World ", TextFormatter.AlignText(text, null, text.Length));
            Assert.Equal(" Hello World      ", TextFormatter.AlignText(text, null, text.Length + 5));
            Assert.Equal(string.Empty, TextFormatter.AlignText(text, null, 0));
            Assert.Throws<ArgumentException>(() => TextFormatter.AlignText(text, null, -1));
        }

        [Fact]
        public void TestAlignTextNoneSingleWord()
        {
            var text = " Hello  ";

            Assert.Equal(" He", TextFormatter.AlignText(text, null, text.Length - 5));
            Assert.Equal(" Hello  ", TextFormatter.AlignText(text, null, text.Length));
            Assert.Equal(" Hello       ", TextFormatter.AlignText(text, null, text.Length + 5));
            Assert.Equal(string.Empty, TextFormatter.AlignText(text, null, 0));
            Assert.Throws<ArgumentException>(() => TextFormatter.AlignText(text, null, -1));
        }

        [Fact]
        public void TestAlignTextLeft()
        {
            var text = " Hello World ";

            Assert.Equal("Hello Wo", TextFormatter.AlignText(text, TextAlignment.Left, text.Length - 5));
            Assert.Equal("Hello World  ", TextFormatter.AlignText(text, TextAlignment.Left, text.Length));
            Assert.Equal("Hello World       ", TextFormatter.AlignText(text, TextAlignment.Left, text.Length + 5));
            Assert.Equal(string.Empty, TextFormatter.AlignText(text, TextAlignment.Left, 0));
            Assert.Throws<ArgumentException>(() => TextFormatter.AlignText(text, TextAlignment.Left, -1));
        }

        [Fact]
        public void TestAlignTextLeftSingleWord()
        {
            var text = " Hello  ";

            Assert.Equal("Hel", TextFormatter.AlignText(text, TextAlignment.Left, text.Length - 5));
            Assert.Equal("Hello   ", TextFormatter.AlignText(text, TextAlignment.Left, text.Length));
            Assert.Equal("Hello        ", TextFormatter.AlignText(text, TextAlignment.Left, text.Length + 5));
            Assert.Equal(string.Empty, TextFormatter.AlignText(text, TextAlignment.Left, 0));
            Assert.Throws<ArgumentException>(() => TextFormatter.AlignText(text, TextAlignment.Left, -1));
        }

        [Fact]
        public void TestAlignTextRight()
        {
            var text = " Hello World ";

            Assert.Equal("lo World", TextFormatter.AlignText(text, TextAlignment.Right, text.Length - 5));
            Assert.Equal("  Hello World", TextFormatter.AlignText(text, TextAlignment.Right, text.Length));
            Assert.Equal("       Hello World", TextFormatter.AlignText(text, TextAlignment.Right, text.Length + 5));
            Assert.Equal(string.Empty, TextFormatter.AlignText(text, TextAlignment.Right, 0));
            Assert.Throws<ArgumentException>(() => TextFormatter.AlignText(text, TextAlignment.Right, -1));
        }

        [Fact]
        public void TestAlignTextRightSingleWord()
        {
            var text = " Hello  ";

            Assert.Equal("llo", TextFormatter.AlignText(text, TextAlignment.Right, text.Length - 5));
            Assert.Equal("   Hello", TextFormatter.AlignText(text, TextAlignment.Right, text.Length));
            Assert.Equal("        Hello", TextFormatter.AlignText(text, TextAlignment.Right, text.Length + 5));
            Assert.Equal(string.Empty, TextFormatter.AlignText(text, TextAlignment.Right, 0));
            Assert.Throws<ArgumentException>(() => TextFormatter.AlignText(text, TextAlignment.Right, -1));
        }

        [Fact]
        public void TestAlignTextCenter()
        {
            var text = " Hello World ";

            Assert.Equal("Hello Wo", TextFormatter.AlignText(text, TextAlignment.Center, text.Length - 5));
            Assert.Equal(" Hello World ", TextFormatter.AlignText(text, TextAlignment.Center, text.Length));
            Assert.Equal("   Hello World    ", TextFormatter.AlignText(text, TextAlignment.Center, text.Length + 5));
            Assert.Equal(string.Empty, TextFormatter.AlignText(text, TextAlignment.Center, 0));
            Assert.Throws<ArgumentException>(() => TextFormatter.AlignText(text, TextAlignment.Center, -1));
        }

        [Fact]
        public void TestAlignTextCenterSingleWord()
        {
            var text = " Hello  ";

            Assert.Equal("Hel", TextFormatter.AlignText(text, TextAlignment.Center, text.Length - 5));
            Assert.Equal(" Hello  ", TextFormatter.AlignText(text, TextAlignment.Center, text.Length));
            Assert.Equal("    Hello    ", TextFormatter.AlignText(text, TextAlignment.Center, text.Length + 5));
            Assert.Equal(string.Empty, TextFormatter.AlignText(text, TextAlignment.Center, 0));
            Assert.Throws<ArgumentException>(() => TextFormatter.AlignText(text, TextAlignment.Center, -1));
        }

        [Fact]
        public void TestAlignTextJustify()
        {
            var text = "  Hello      World again and again  ";

            Assert.Equal("Hello Worl", TextFormatter.AlignText(text, TextAlignment.Justify, 10));
            Assert.Equal("Hello World again and again", TextFormatter.AlignText(text, TextAlignment.Justify, 27));
            Assert.Equal("Hello  World  again and  again", TextFormatter.AlignText(text, TextAlignment.Justify, 30));
            Assert.Equal(string.Empty, TextFormatter.AlignText(text, TextAlignment.Justify , 0));
            Assert.Throws<ArgumentException>(() => TextFormatter.AlignText(text, TextAlignment.Justify, -1));
        }

        [Fact]
        public void TestAlignTextJustifySingleWord()
        {
            var text = " Hello  ";

            Assert.Equal("Hel", TextFormatter.AlignText(text, TextAlignment.Justify, 3));
            Assert.Equal("Hello", TextFormatter.AlignText(text, TextAlignment.Justify, 5));
            Assert.Equal("Hello   ", TextFormatter.AlignText(text, TextAlignment.Justify, 8));
            Assert.Equal(string.Empty, TextFormatter.AlignText(text, TextAlignment.Justify , 0));
            Assert.Throws<ArgumentException>(() => TextFormatter.AlignText(text, TextAlignment.Justify, -1));
        }

    }
}
