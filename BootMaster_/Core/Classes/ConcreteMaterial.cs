namespace BudMayster.Classes
{
    class ConcreteMaterial : Material
    {
        public ConcreteMaterial(int id, string name, int quantity, decimal price_zakup, decimal perc_zakup, decimal price_opt, decimal perc_opt, decimal price_prod)
            : base(id, name, quantity, price_zakup, perc_zakup,  price_opt, perc_opt, price_prod)
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
    }
}