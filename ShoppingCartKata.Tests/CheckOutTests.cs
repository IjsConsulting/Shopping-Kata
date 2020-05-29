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

        #region Scan Tests

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Scan_WithInvalidSku_ThrowsException()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan("A01");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Scan_WithNullSku_ThrowsException()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Scan_WithEmptyStringSku_ThrowsException()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan(string.Empty);
        }

        [TestMethod]
        public void Scan_AddSingleItem_TotalIsCorrect()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan("A99");

            //Assert.
            Assert.AreEqual(0.5m, checkOut.Total());
        }

        [TestMethod]
        public void Scan_AddTwoSameItems_TotalIsCorrect()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan("A99");
            checkOut.Scan("A99");

            //Assert.
            Assert.AreEqual(1.0m, checkOut.Total());
        }

        [TestMethod]
        public void Scan_AddTwoDifferentItems_TotalIsCorrect()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan("A99");
            checkOut.Scan("B15");

            //Assert.
            Assert.AreEqual(0.8m, checkOut.Total());
        }

        [TestMethod]
        public void Scan_AddThreeDifferentItems_TotalIsCorrect()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan("A99");
            checkOut.Scan("B15");
            checkOut.Scan("C40");

            //Assert.
            Assert.AreEqual(1.4m, checkOut.Total());
        }

        [TestMethod]
        public void Scan_AddFourSameItemsWithNoDiscountApplied_TotalIsCorrect()
        {
            //Arrange
            var products = GetProducts();
            var discounts = new List<IDiscount>();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan("A99");
            checkOut.Scan("A99");
            checkOut.Scan("A99");
            checkOut.Scan("A99");

            //Assert.
            Assert.AreEqual(2.0m, checkOut.Total());
        }

        #endregion

        #region Discount Tests

        [TestMethod]
        public void Scan_AddItemsThatQualifyForDiscount_DiscountAppliedToTotal()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan("A99");
            checkOut.Scan("A99");
            checkOut.Scan("A99");

            //Assert.
            Assert.AreEqual(1.3m, checkOut.Total());
        }

        [TestMethod]
        public void Scan_AddFourItemsThatQualifyForDiscount_DiscountAppliedToTotal()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan("A99");
            checkOut.Scan("A99");
            checkOut.Scan("A99");
            checkOut.Scan("A99");

            //Assert.
            Assert.AreEqual(1.8m, checkOut.Total());
        }

        [TestMethod]
        public void Scan_AddItemsWithDiscountAndOtherItem_DiscountAppliedToTotal()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan("A99");
            checkOut.Scan("A99");
            checkOut.Scan("A99");
            checkOut.Scan("B15");

            //Assert.
            Assert.AreEqual(1.6m, checkOut.Total());
        }

        [TestMethod]
        public void Scan_AddTwoItemsWithDiscount_DiscountAppliedToTotal()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan("A99");
            checkOut.Scan("A99");
            checkOut.Scan("A99");
            checkOut.Scan("B15");
            checkOut.Scan("B15");

            //Assert.
            Assert.AreEqual(1.75m, checkOut.Total());
        }

        [TestMethod]
        public void Scan_AddTwoItemsWithDiscountAndOneNonDiscount_DiscountAppliedToTotal()
        {
            //Arrange
            var products = GetProducts();
            var discounts = GetDiscounts();

            var checkOut = new CheckOut(products, discounts);

            //Act
            checkOut.Scan("A99");
            checkOut.Scan("A99");
            checkOut.Scan("A99");
            checkOut.Scan("B15");
            checkOut.Scan("B15");
            checkOut.Scan("C40");

            //Assert.
            Assert.AreEqual(2.35m, checkOut.Total());
        }

        #endregion

        #region Private functions

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
