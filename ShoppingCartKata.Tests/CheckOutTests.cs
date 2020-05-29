using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartKata.Lib.Entities;

namespace ShoppingCartKata.Lib.Tests
{
    [TestClass]
    public class CheckOutTests
    {
        #region Constructor tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithNullProductList_ThrowsException()
        {
            //Arrange
            var discounts = GetDiscounts();

            //Act
            var checkOut = new CheckOut(null, discounts);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithNullDiscountList_ThrowsException()
        {
            //Arrange
            var products = GetProducts();

            //Act
            var checkOut = new CheckOut(products, null);
        }

        [TestMethod]
        public void Constructor_ProvideProductsAndDiscounts_ObjectCreated()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            //Act
            var checkOut = new CheckOut(products, discounts);
            
            //Assert.
            Assert.IsNotNull(checkOut);
            Assert.IsInstanceOfType(checkOut, typeof(ICheckOut));
        }

        #endregion

        #region Privation functions

        private IEnumerable<IProduct> GetProducts()
        {
            return new List<IProduct>
            {
                new Product("A99", 0.50m),
                new Product("B15", 0.30m),
                new Product("C40", 0.60m)
            };
        }

        private IEnumerable<IDiscount> GetDiscounts()
        {
            return new List<IDiscount>
            {
                new Discount("A99", 3, 1.30m),
                new Discount("B15",2, 0.45m),
            };
        }

        #endregion
    }
}
