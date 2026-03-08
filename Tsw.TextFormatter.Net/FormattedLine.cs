namespace Tsw.TextFormatter.Net
{
    public class FormattedLine : List<FormattedText>
    {
        public override string ToString() =>
            string.Join("", this.Select(x => x.Text));
    }
}
