using BudMayster.Classes;
using BudMayster.Interfaces;
using Moq;

namespace TestProject
{
    public class TestConcreteMaterial : Material
    {
        public TestConcreteMaterial(int id, string name, int quantity, decimal price_zakup, decimal perc_zakup, decimal price_opt, decimal perc_opt, decimal price_prod)
            : base(id, name, quantity, price_zakup, perc_zakup, price_opt, perc_opt, price_prod)
        {
        }

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity < 0)
                throw new ArgumentException("Кількість не може бути від'ємною.");

            Quantity = newQuantity;
        }

        public void UpdatePrices(decimal newPriceZakup, decimal newPriceOpt, decimal newPriceProd)
        {
            if (newPriceZakup <= 0 || newPriceOpt <= 0 || newPriceProd <= 0)
                throw new ArgumentException("Ціни мають бути більше нуля.");

            Price_zakup = newPriceZakup;
            Price_opt = newPriceOpt;
            Price_prod = newPriceProd;
        }

        [TestMethod]
        public void UpdateQuantity_ValidValue_UpdatesQuantity_Moq()
        {
            var mockMaterial = new Mock<IМaterial>();
            mockMaterial.SetupProperty(m => m.Quantity, 10);

            mockMaterial.Object.UpdateQuantity(20);

            mockMaterial.Verify(m => m.UpdateQuantity(20), Times.Once);
        }

        [TestMethod]
        public void UpdatePrices_ValidValues_UpdatesPrices_Moq()
        {
            var mockMaterial = new Mock<IМaterial>();
            mockMaterial.SetupProperty(m => m.Price_zakup);
            mockMaterial.SetupProperty(m => m.Price_opt);
            mockMaterial.SetupProperty(m => m.Price_prod);

            mockMaterial.Object.UpdatePrices(100, 150, 200);

            mockMaterial.Verify(m => m.UpdatePrices(100, 150, 200), Times.Once);
        }
    }

}
