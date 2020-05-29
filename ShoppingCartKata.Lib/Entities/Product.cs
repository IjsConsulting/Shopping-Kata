using System;

namespace ShoppingCartKata.Lib.Entities
{
    /// <summary>
    /// Represents a Product Entity
    /// </summary>
    public class Product : IProduct
    {
        public Product(string sku, decimal unitPrice)
        {
            if (string.IsNullOrEmpty(sku)) throw new Exception("Sku cannot be empty or null");

            if (unitPrice < 0.0m) throw new Exception("unitPrice cannot be less than 0.");

            SKU = sku;
            UnitPrice = unitPrice;
        }

        /// <summary>
        /// The Stock Keeping Unit (SKU) identifier.
        /// </summary>
        public string SKU { get; }

        /// <summary>
        /// The unit price of the product
        /// </summary>
        public decimal UnitPrice { get; } = 0.0m;
    }
}
