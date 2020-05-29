namespace ShoppingCartKata.Lib.Entities
{
    /// <summary>
    /// Represents an interface for a Product Entity
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// The Stock Keeping Unit (SKU) identifier.
        /// </summary>
        string SKU { get; }
        
        /// <summary>
        /// The unit price of the product
        /// </summary>
        decimal UnitPrice { get; }
    }
}
