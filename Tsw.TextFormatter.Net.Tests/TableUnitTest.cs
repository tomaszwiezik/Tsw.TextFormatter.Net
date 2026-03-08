namespace Tsw.TextFormatter.Net.Tests
{
    public class TableUnitTest
    {
        [Fact]
        public void TestTableCreation()
        {
            var table = new Tables.Table([]);

            Assert.NotNull(table);
        }

        [Fact]
        public void TextOfEmptyTableShouldBeEmpty()
        {
            var table = new Tables.Table([]);

            Assert.Equal(string.Empty, table.ToString());
        }

        [Fact]
        public void TestAddColumnsWithoutRenderingAnything()
        {
            var table = new Tables.Table([
                new Tables.TableColumn(Text: "Column1"),
                new Tables.TableColumn(Text: "Column2")
                ]);
            table.AddHeader();

            Assert.Equal(string.Empty, table.ToString());
        }
    }
}
