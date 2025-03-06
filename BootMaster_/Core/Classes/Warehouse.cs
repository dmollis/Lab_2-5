using BudMayster.Interfaces;

namespace BudMayster.Classes
{
    internal class Warehouse : IWarehouseManagement
    {
        /* Цей клас реалізує інтерфейс IWarehouseManagement. 
         * Міститиме список товарів, та, як мінімум, три методи управління ними: 
         * Облік надходжень товарів
         * Відвантаження товарів 
         * Інвентарізація товарів */

        public void InventoryCheck()
        {
            throw new NotImplementedException();
        }

        public void ReceiveStock(IМaterial material, int quantity)
        {
            throw new NotImplementedException();
        }

        public void ShipStock(IМaterial material, int quantity)
        {
            throw new NotImplementedException();
        }

        /*private List<IМaterial> stock = new();

        public void ReceiveStock(IМaterial material, int quantity)
        {
            material.Quantity += quantity;
        }

        public void ShipStock(IМaterial material, int quantity)
        {
            if (material.Quantity >= quantity)
                material.Quantity -= quantity;
            else
                MessageBox.Show("Недостатньо матеріалів на складі!");
        }

        public void InventoryCheck()
        {
            string stockDetails = "Інвентаризація:\n";
            foreach (var item in stock)
            {
                stockDetails += $"{item.Name} - {item.Quantity} шт.\n";
            }
            MessageBox.Show(stockDetails);
        }*/
    }
}
