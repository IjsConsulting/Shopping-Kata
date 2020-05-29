namespace ShoppingCartKata.Lib
{
    /// <summary>
    /// INterface for a CheckOUt object.
    /// </summary>
    public interface ICheckOut
    {
        /// <summary>
        /// Scan a products SKU and adds to the running total of products scanned.
        /// </summary>
        /// <param name="sku">The product SKU</param>
        void Scan(string sku);

        /// <summary>
        /// Returns the total amount due, with any discounts applied. 
        /// </summary>
        /// <returns>Product Price.</returns>
        decimal Total();
    }
}