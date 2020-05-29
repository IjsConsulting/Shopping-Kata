using System;

namespace ShoppingCartKata.Lib.Entities
{
    /// <summary>
    /// Represents a Dicsount Entity
    /// </summary>
    public class Discount : IDiscount
    {
        public Discount(string sku, int quantity, decimal offerPrice)
        {
            if (string.IsNullOrEmpty(sku)) throw new Exception("Sku cannot be empty or null");

            if (quantity < 0) throw new Exception("Quantity cannot be less than 0.");

            if (offerPrice < 0.0m) throw new Exception("OfferPrice cannot be less than 0.");

            SKU = sku;
            Quantity = quantity;
            OfferPrice = offerPrice;
        }

        /// <summary>
        /// The Stock Keeping Unit (SKU)
        /// </summary>
        public string SKU { get; }

        /// <summary>
        /// Discount Quantity
        /// </summary>
        public int Quantity { get; } = 0;

        /// <summary>
        /// The Price at which the discount is offered.
        /// </summary>
        public decimal OfferPrice { get; } = 0.0m;
    }
}