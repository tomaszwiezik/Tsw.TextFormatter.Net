namespace Tsw.TextFormatter.Net.Tables
{
    public interface ITableLayout
    {
        public bool IgnoreHeader { get; }
        public bool IgnoreRowSeparators { get; }
        public TextLine Format(TextLine tableRow);
    }
}
