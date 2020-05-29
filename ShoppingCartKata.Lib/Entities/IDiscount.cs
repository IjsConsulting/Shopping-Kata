namespace ShoppingCartKata.Lib.Entities
{
    /// <summary>
    /// Represents an interface for a Discount Entity
    /// </summary>
    public interface IDiscount
    {
        /// <summary>
        /// The Stock Keeping Unit (SKU) identifier.
        /// </summary>
        string SKU { get; }

        /// <summary>
        /// Discount Quantity
        /// </summary>
        int Quantity { get; }

        /// <summary>
        /// The Price at which the discount is offered.
        /// </summary>
        decimal OfferPrice { get; }
    }
}