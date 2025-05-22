namespace BudMayster.Interfaces
{
    public interface IМaterial
    {
        /*Повинен бути метод що повертає назву матеріалу.
        Повинен бути метод що визначає кількість матеріалу.
        Повинен бути метод що повертає ціну за одиницю матеріалу.
        Повинен бути метод що виводить інформацію про матеріал (назва, кількість, ціна).
        Призначення:
        -Забезпечує уніфікований спосіб роботи з матеріалами.
        -Дозволяє відображати інформацію про матеріал у стандартизованому форматі.*/
        int ID { get; }
        string Name { get; }
        int Quantity { get; set; }
        int Supplier_id { get; set; }
        decimal Price_zakup { get;}
        decimal Price_opt { get; }
        decimal Price_prod { get; }
        string ToString();
        void UpdateQuantity(int newQuantity);
        void UpdatePrices(decimal zakup, decimal opt, decimal prod);
    }
}
