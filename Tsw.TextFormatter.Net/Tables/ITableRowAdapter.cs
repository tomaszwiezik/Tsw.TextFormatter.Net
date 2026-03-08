namespace Tsw.TextFormatter.Net.Tables
{
    /// <summary>
    /// Table row adapter interface to convert a row of type T to a TableRow.
    /// The adapter is neccessary for the table to be able to convert a custom type to a format that can be rendered.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITableRowAdapter<T>
    {
        /// <summary>
        /// Transforms an object of custom type T to a TableRow that can be rendered by the table.
        /// </summary>
        /// <param name="row">The object to transform.</param>
        /// <returns></returns>
        TableRow GetRow(T row);
    }
}
