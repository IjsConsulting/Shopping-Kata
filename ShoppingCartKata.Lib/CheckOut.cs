using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using ShoppingCartKata.Lib.Entities;

namespace ShoppingCartKata.Lib
{
    /// <summary>
    /// Class represents a CheckOut object, that scans a prodcut (SKU)
    /// and returns the total amount with any applicable discounts applied.
    /// </summary>
    public class CheckOut : ICheckOut
    {
        List<string> scannedSkus = new List<string>();
        readonly IEnumerable<IProduct> products;
        readonly IEnumerable<IDiscount> discounts;

        public CheckOut(IEnumerable<IProduct> products, IEnumerable<IDiscount> discounts)
        {
            if (products == null) throw new ArgumentException("products");
            if (discounts == null) throw new ArgumentException("discounts");

            this.products = products;
            this.discounts = discounts;
        }

        /// <summary>
        /// Scan a products SKU and adds to the running total of products scanned.
        /// </summary>
        /// <param name="sku">The product SKU</param>
        public void Scan(string sku)
        {
            if (string.IsNullOrEmpty(sku))
            {
                throw new Exception($"Cannot scan and empty Sku.");
            }

            if (!products.Any(product => product.SKU.Equals(sku)))
            {
                throw new Exception($"Cannot scan this product with Sku, {sku}.");
            };

            scannedSkus.Add(sku);
        }

        /// <summary>
        /// Returns the total amount due, with any discounts applied. 
        /// </summary>
        /// <returns>Product Price.</returns>
        public decimal Total()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the discount to be applied, on a per product SKU basis.
        /// </summary>
        /// <param name="discount">Instance of a IDiscount</param>
        /// <returns>Discount amount</returns>
        private decimal CalculateDiscount(IDiscount discount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the product price by SKU.
        /// </summary>
        /// <param name="sku">Product SKU</param>
        /// <returns>Product price</returns>
        private decimal GetPrice(string sku)
        {
            throw new NotImplementedException();
        }        
    }
}
