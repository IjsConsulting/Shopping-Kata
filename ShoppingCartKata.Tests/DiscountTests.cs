using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartKata.Lib.Entities;

namespace ShoppingCartKata.Tests
{
    [TestClass]
    public class DiscountTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_NullSku_ThrowsException()
        {
            //Arrange
            var product = new Discount(null, 3, 1.30m);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_EmptySku_ThrowsException()
        {
            //Arrange
            var product = new Discount("", 3, 1.30m);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_QuantityLessThanZero_ThrowsException()
        {
            //Arrange
            var product = new Discount("A99", -3, 1.30m);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_OfferPriceLessThanZero_ThrowsException()
        {
            //Arrange
            var product = new Discount("A99", 3, -1.30m);
        }

        [TestMethod]
        public void Constructor_WithSkuAndPositiveUnitP_ThrowException()
        {
            //Arrange
            var product = new Discount("A99", 3, 1.30m);
        }
    }
}
