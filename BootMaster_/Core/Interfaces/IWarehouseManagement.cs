namespace BudMayster.Interfaces
{
    public interface IWarehouseManagement
    {
        /*Повинен бути метод що додає матеріал на склад або збільшує його кількість.
         Повинен бути метод що відвантажує матеріал зі складу, зменшуючи його кількість.
        Повинен бути метод що виконує перевірку запасів на складі та виводить інформацію про всі наявні матеріали.
        Призначення:
        -Забезпечує управління надходженням та відвантаженням матеріалів.
        -Дозволяє проводити інвентаризацію складу.*/

        void ReceiveStock(IМaterial material, int quantity);
        void ShipStock(IМaterial material, int quantity);
        void InventoryCheck();
    }
}
