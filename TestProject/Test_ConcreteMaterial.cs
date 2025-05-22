using BudMayster.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TestProject;

namespace BudMayster.Tests
{
    [TestClass]
    public class ConcreteMaterialTests
    {
        [TestMethod]
        public void UpdateQuantity_ValidQuantity_ShouldUpdateQuantity()
        {
            var material = new TestConcreteMaterial(1, "Concrete", 100, 500, 10, 600, 15, 700);

            material.UpdateQuantity(150);

            Assert.AreEqual(150, material.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateQuantity_NegativeQuantity_ShouldThrowArgumentException()
        {
            var material = new TestConcreteMaterial(1, "Concrete", 100, 500, 10, 600, 15, 700);

            material.UpdateQuantity(-50);
        }

        [TestMethod]
        public void UpdatePrices_ValidPrices_ShouldUpdatePrices()
        {
            var material = new TestConcreteMaterial(1, "Concrete", 100, 500, 10, 600, 15, 700);

            material.UpdatePrices(550, 650, 750);

            Assert.AreEqual(550, material.Price_zakup);
            Assert.AreEqual(650, material.Price_opt);
            Assert.AreEqual(750, material.Price_prod);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdatePrices_InvalidPrice_ShouldThrowArgumentException()
        {
            var material = new TestConcreteMaterial(1, "Concrete", 100, 500, 10, 600, 15, 700);

            material.UpdatePrices(-550, 650, 750);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdatePrices_ZeroPrice_ShouldThrowArgumentException()
        {
            var material = new TestConcreteMaterial(1, "Concrete", 100, 500, 10, 600, 15, 700);

            material.UpdatePrices(550, 0, 750);
        }



        [TestMethod]
        public void UpdateQuantity_ValidQuantity_ShouldUpdateQuantity_Moq()
        {
            var mock = new Mock<IÌaterial>();
            mock.SetupProperty(m => m.Quantity, 100);

            mock.Setup(m => m.UpdateQuantity(It.IsAny<int>()))
                .Callback<int>(q => mock.Object.Quantity = q);

            mock.Object.UpdateQuantity(150);

            Assert.AreEqual(150, mock.Object.Quantity);
        }

        [TestMethod]
        public void UpdateQuantity_NegativeQuantity_ShouldThrowArgumentException_Moq()
        {
            var mock = new Mock<IÌaterial>();
            mock.Setup(m => m.UpdateQuantity(It.Is<int>(q => q < 0)))
                .Throws<ArgumentException>();

            Assert.ThrowsException<ArgumentException>(() => mock.Object.UpdateQuantity(-50));
        }

        [TestMethod]
        public void UpdatePrices_InvalidPrice_ShouldThrowArgumentException_Moq()
        {
            var mock = new Mock<IÌaterial>();
            mock.Setup(m => m.UpdatePrices(It.Is<decimal>(z => z < 0), It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Throws<ArgumentException>();

            Assert.ThrowsException<ArgumentException>(() => mock.Object.UpdatePrices(-550, 650, 750));
        }

        [TestMethod]
        public void UpdatePrices_ZeroPrice_ShouldThrowArgumentException_Moq()
        {
            var mock = new Mock<IÌaterial>();
            mock.Setup(m => m.UpdatePrices(It.IsAny<decimal>(), It.Is<decimal>(o => o <= 0), It.IsAny<decimal>()))
                .Throws<ArgumentException>();

            Assert.ThrowsException<ArgumentException>(() => mock.Object.UpdatePrices(550, 0, 750));
        }
    }
}
