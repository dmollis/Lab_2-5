using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
