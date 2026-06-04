using Tsw.TextFormatter.Net.Tables;

namespace Tsw.TextFormatter.Net.Tests.Tables
{
    public class TableUnitTest
    {
        [Fact]
        public void TestTableCreation()
        {
            var table = new Table([]);

            Assert.NotNull(table);
        }

        [Fact]
        public void TextOfEmptyTableShouldBeEmpty()
        {
            var table = new Table([]);

            Assert.Equal(string.Empty, table.ToString());
        }

        [Fact]
        public void TestAddColumnsWithoutConteneCells()
        {
            var table = new Table([
                new TableColumn(Text: "Column1"),
                new TableColumn(Text: "Column2")
                ]);
            table.AddHeader();

            Assert.Equal("Column1 Column2", table.ToString());
        }
    }
}
