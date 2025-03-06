using BudMayster.Interfaces;

namespace BudMayster.Classes
{
    internal class Material : IМaterial
    {
        /* Цей клас реалізує інтерфейс IМaterial. 
         * Міститиме властивості товарів (як мінімум три), такі як:
         * Ім'я
         * Кількість
         * Ціна
         * та метод виведення їх опису на екран. */

        public string Name => throw new NotImplementedException();

        public int Quantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public decimal Price => throw new NotImplementedException();

        public void DisplayInfo()
        {
            throw new NotImplementedException();
        }

        /*public string Name { get; }
        public int Quantity { get; set; }
        public decimal Price { get; }

        public Material(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public void DisplayInfo()
        {
            MessageBox.Show($"Матеріал: {Name}\nКількість: {Quantity}\nЦіна: {Price}");
        }*/

    }
}
