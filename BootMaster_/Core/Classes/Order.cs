using BudMayster.Interfaces;

namespace BudMayster.Classes
{
    internal class Order : IOrder
    {
        /* Цей клас реалізує інтерфейс IOrder. 
         * Міститиме словник товарів, та, як мінімум, чотири методи роботи з замовленнями: 
         * Додавання товарів
         * Видалення товарів 
         * Обчислення загальної суми
         * Виведення замовлення на екран */

        public void AddMaterial(IМaterial material, int quantity)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTotal()
        {
            throw new NotImplementedException();
        }

        public void DisplayOrder()
        {
            throw new NotImplementedException();
        }

        public void RemoveMaterial(IМaterial material)
        {
            throw new NotImplementedException();
        }

        /*private Dictionary<IМaterial, int> materials = new();

        public void AddMaterial(IМaterial material, int quantity)
        {
            if (materials.ContainsKey(material))
                materials[material] += quantity;
            else
                materials[material] = quantity;
        }

        public void RemoveMaterial(IМaterial material)
        {
            materials.Remove(material);
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in materials)
                total += item.Key.Price * item.Value;
            return total;
        }

        public void DisplayOrder()
        {
            string orderDetails = "Замовлення:\n";
            foreach (var item in materials)
            {
                orderDetails += $"{item.Key.Name} - {item.Value} шт.\n";
            }
            orderDetails += $"Загальна вартість: {CalculateTotal()}";
            MessageBox.Show(orderDetails);
        }*/
    }
}
