namespace Tsw.TextFormatter.Net
{
    public class TextLine : List<TextSegment>
    {
        public override string ToString() =>
            string.Join("", this.Select(x => x.Text));
    }
}
