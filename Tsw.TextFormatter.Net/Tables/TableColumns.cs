namespace Tsw.TextFormatter.Net.Tables
{
    public class TableColumns : List<TableColumn>
    {
        public TableColumns() { }
        public TableColumns(IEnumerable<TableColumn> collection) : base(collection) { }


        /// <summary>
        /// Set all auto-with columns to the maximum width of the content in that column, including the header text.
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="rows"></param>
        public TableColumns SetWidth(TableRows rows)
        {
            var formattedColumns = new TableColumns();
            for (var i = 0; i < this.Count; i++)
            {
                var column = this[i];
                var maxContentWidth = column.Width == TextWidth.Auto ?
                    rows
                        .FindAll(row => i < row.Count)
                        .Select(row => row.ElementAt(i).Text.Length)
                        .DefaultIfEmpty(0)
                        .Max() :
                    column.Width;
                maxContentWidth = Math.Max(maxContentWidth, column.Text.Length);

                formattedColumns.Add(new TableColumn(
                    Text: column.Text.Align(column.Alignment, maxContentWidth),
                    ForegroundColor: column.ForegroundColor,
                    BackgroundColor: column.BackgroundColor,
                    Alignment: column.Alignment,
                    CellAlignment: column.CellAlignment,
                    Width: maxContentWidth
                ));
            }
            return formattedColumns;
        }
    }
}
