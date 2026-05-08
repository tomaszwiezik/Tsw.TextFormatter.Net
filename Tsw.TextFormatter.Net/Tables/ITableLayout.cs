namespace Tsw.TextFormatter.Net.Tables
{
    public interface ITableLayout
    {
        public bool IgnoreSeparators { get; }
        public TextLine Format(TextLine tableRow);
    }
}
