using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartKata.Lib.Entities;

namespace ShoppingCartKata.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_NullSku_ThrowsException()
        {
            //Arrange
            var product = new Product(null, 0.30m);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_EmptySku_ThrowsException()
        {
            //Arrange
            var product = new Product(string.Empty, 0.30m);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_UnitPriceLessThanZero_ThrowsException()
        {
            //Arrange
            var product = new Product("A99", -0.5m);
        }

        [TestMethod]
        public void Constructor_WithSkuAndPositiveUnitP_ThrowException()
        {
            //Arrange
            var product = new Product("A99", 0.5m);
        }
    }
}
