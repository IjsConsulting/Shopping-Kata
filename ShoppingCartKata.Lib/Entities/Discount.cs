using System;

namespace ShoppingCartKata.Lib.Entities
{
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

        public string SKU { get; }

        public int Quantity { get; } = 0;

        public decimal OfferPrice { get; } = 0.0m;
    }
}