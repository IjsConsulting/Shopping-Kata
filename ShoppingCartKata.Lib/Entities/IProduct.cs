namespace ShoppingCartKata.Lib.Entities
{
    public interface IProduct
    {
        string SKU { get; }
        decimal UnitPrice { get; }
    }
}
