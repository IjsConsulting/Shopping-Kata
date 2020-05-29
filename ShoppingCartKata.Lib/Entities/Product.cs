using System;

namespace ShoppingCartKata.Lib.Entities
{
    public class Product : IProduct
    {
        public Product(string sku, decimal unitPrice)
        {
            if (string.IsNullOrEmpty(sku)) throw new Exception("Sku cannot be empty or null");

            if (unitPrice < 0.0m) throw new Exception("unitPrice cannot be less than 0.");

            SKU = sku;
            UnitPrice = unitPrice;
        }

        public string SKU { get; }

        public decimal UnitPrice { get; } = 0.0m;
    }
}
