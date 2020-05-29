namespace ShoppingCartKata.Lib.Entities
{
    public interface IDiscount
    {
        string SKU { get; }
        int Quantity { get; }
        decimal OfferPrice { get; }
    }
}