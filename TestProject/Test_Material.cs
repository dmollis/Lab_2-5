using Microsoft.VisualStudio.TestTools.UnitTesting;
using BudMayster.Classes;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TestProject;
using Moq;
using BudMayster.Interfaces;
using BudMayster_.Core.Classes;

namespace BudMayster.Tests
{
    [TestClass]
    public class MaterialTests
    {
        [TestMethod]
        public void Constructor_ShouldCreateMaterial_WhenValidParameters()
        {
            var material = new TestConcreteMaterial(1, "Test Material", 10, 100.0m, 10.0m, 120.0m, 15.0m, 150.0m);

            Assert.AreEqual(1, material.ID);
            Assert.AreEqual("Test Material", material.Name);
            Assert.AreEqual(10, material.Quantity);
            Assert.AreEqual(100.0m, material.Price_zakup);
            Assert.AreEqual(10.0m, material.Percent_zakup);
            Assert.AreEqual(120.0m, material.Price_opt);
            Assert.AreEqual(15.0m, material.Percent_opt);
            Assert.AreEqual(150.0m, material.Price_prod);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_ShouldThrowArgumentException_WhenNameIsEmpty()
        {
            var material = new TestConcreteMaterial(1, "", 10, 100.0m, 10.0m, 120.0m, 15.0m, 150.0m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_ShouldThrowArgumentException_WhenQuantityIsNegative()
        {
            var material = new TestConcreteMaterial(1, "Test Material", -1, 100.0m, 10.0m, 120.0m, 15.0m, 150.0m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_ShouldThrowArgumentException_WhenPriceZakupIsNegative()
        {
            var material = new TestConcreteMaterial(1, "Test Material", 10, -100.0m, 10.0m, 120.0m, 15.0m, 150.0m);
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectString()
        {
            var material = new TestConcreteMaterial(1, "Test Material", 10, 100.0m, 10.0m, 120.0m, 15.0m, 150.0m);
            var expectedString = "Назва: Test Material\n" +
                                 "Кількість на складі: 10 шт.\n" +
                                 "Ціна закупівлі: 100,0 ₴\n" +
                                 "Ціна опту: 120,0 ₴\n" +
                                 "Ціна продажу: 150,0 ₴\n";
            Assert.AreEqual(expectedString, material.ToString());
        }

        [TestMethod]
        public void PrintMaterial_ShouldReturnCorrectString_Moq()
        {
            var mockMaterial = new Mock<IМaterial>();
            mockMaterial.Setup(m => m.ToString()).Returns(
                "Назва: Test Material\n" +
                "Кількість на складі: 10 шт.\n" +
                "Ціна закупівлі: 100,0 ₴\n" +
                "Ціна опту: 120,0 ₴\n" +
                "Ціна продажу: 150,0 ₴\n"
            );

            var printer = new MaterialPrinter(mockMaterial.Object);

            var result = printer.PrintMaterial();

            Assert.AreEqual(mockMaterial.Object.ToString(), result);
        }
    }
}
