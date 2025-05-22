using BudMayster_.Core.Classes;
using BudMayster.Interfaces;
using MySql.Data.MySqlClient;
using BudMayster_.Core.Interfaces;

namespace BudMayster.Classes
{
    public abstract class Material : IМaterial
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Supplier_id { get; set; }
        public decimal Price_zakup { get; set; }
        public decimal Price_opt { get; set; }
        public decimal Price_prod { get; set; }
        public decimal Percent_zakup { get; set; }
        public decimal Percent_opt { get; set; }
        private readonly IDatabaseConnection _dbConnection;

        public Material()
        {
        }

        public Material(int id, string name, int quantity, decimal price_zakup, decimal perc_zakup, decimal price_opt, decimal perc_opt, decimal price_prod)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва товару не може бути порожньою.");

            if (quantity < 0)
                throw new ArgumentException("Кількість має бути більше нуля.");

            if (price_zakup < 0)
                throw new ArgumentException("Ціна має бути більше нуля.");

            if (perc_zakup < 0)
                throw new ArgumentException("% має бути більше нуля.");

            if (price_opt < 0)
                throw new ArgumentException("Ціна має бути більше нуля.");

            if (perc_opt < 0)
                throw new ArgumentException("% має бути більше нуля.");

            if (price_prod < 0)
                throw new ArgumentException("Ціна має бути більше нуля.");

            ID = id;
            Name = name;
            Quantity = quantity;
            Price_zakup = price_zakup;
            Percent_zakup = perc_zakup;
            Price_opt = price_opt;
            Percent_opt = perc_opt;
            Price_prod = price_prod;
        }

        // Потребує таких тестових наборів:
        // - Валідні дані (усі значення > 0 або не порожні) — перевірка створення об'єкта без виключень.
        // - Невалідна назва (null, "", "   ") — очікується ArgumentException.
        // - Кількість < 0 — очікується ArgumentException.
        // - Будь-яка з цін < 0 — очікується ArgumentException.
        // - Будь-який з відсотків < 0 — очікується ArgumentException.

        public Material(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        // Потребує таких тестових наборів:
        // - Валідний об'єкт підключення до БД — перевірка правильного збереження залежності.
        // - null як dbConnection — очікується ArgumentNullException.

        public Material(
            IDatabaseConnection dbConnection,
            int id,
            string name,
            int quantity,
            decimal price_zakup,
            decimal perc_zakup,
            decimal price_opt,
            decimal perc_opt,
            decimal price_prod) : this(dbConnection)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва товару не може бути порожньою.");

            if (quantity < 0)
                throw new ArgumentException("Кількість має бути більше нуля.");

            if (price_zakup < 0)
                throw new ArgumentException("Ціна має бути більше нуля.");

            if (perc_zakup < 0)
                throw new ArgumentException("% має бути більше нуля.");

            if (price_opt < 0)
                throw new ArgumentException("Ціна має бути більше нуля.");

            if (perc_opt < 0)
                throw new ArgumentException("% має бути більше нуля.");

            if (price_prod < 0)
                throw new ArgumentException("Ціна має бути більше нуля.");

            ID = id;
            Name = name;
            Quantity = quantity;
            Price_zakup = price_zakup;
            Percent_zakup = perc_zakup;
            Price_opt = price_opt;
            Percent_opt = perc_opt;
            Price_prod = price_prod;
        }

        // Потребує таких тестових наборів:
        // - Валідні значення (включно з підключенням до БД) — перевірка створення без виключень.
        // - null як dbConnection — очікується ArgumentNullException.
        // - Невалідна назва, кількість, ціни або відсотки — очікується ArgumentException.

        public override string ToString()
        {
            return $"Назва: {Name}\n" +
                   $"Кількість на складі: {Quantity} шт.\n" +
                   $"Ціна закупівлі: {Price_zakup} ₴\n" +
                   $"Ціна опту: {Price_opt} ₴\n" +
                   $"Ціна продажу: {Price_prod} ₴\n";
        }

        // Потребує таких тестових наборів:
        // - Об'єкт з наперед заданими значеннями Name, Quantity, Price_zakup, Price_opt, Price_prod — перевірка правильності форматування рядка.
        // - Граничні значення (наприклад, Quantity = 0, Price_zakup = 0.01) — перевірка форматування.

        public List<Material> GetMaterials()
        {
            List<Material> materials = new List<Material>();

            try
            {
                _dbConnection.OpenConnection();
                string query = "SELECT id, name, supplier_id, price_zakup, `%_zakup`, price_opt, `%_opt`, price_prod, quantity FROM materials";

                using (MySqlCommand cmd = new MySqlCommand(query, _dbConnection.GetConnection()))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var material = new ConcreteMaterial(
                                _dbConnection,
                                reader.GetInt32("id"),
                                reader.GetString("name"),
                                reader.GetInt32("quantity"),
                                reader.GetDecimal("price_zakup"),
                                reader.GetDecimal("%_zakup"),
                                reader.GetDecimal("price_opt"),
                                reader.GetDecimal("%_opt"),
                                reader.GetDecimal("price_prod")
                            );

                            materials.Add(material);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Помилка під час отримання матеріалів: {ex.Message}");
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
            return materials;
        }

        // Потребує таких тестових наборів:
        // - БД містить кілька валідних записів — перевірка правильного зчитування і мапінгу у список.
        // - БД порожня — перевірка, що метод повертає порожній список.
        // - БД повертає записи з null або неочікуваними типами — очікується відповідна обробка або виключення.
        // - Виникає помилка з'єднання з БД — перевірка, що кидається виключення з відповідним повідомленням.

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity < 0)
                throw new ArgumentException("Кількість не може бути від'ємною.");

            Quantity = newQuantity;
        }

        // Потребує таких тестових наборів:
        // - newQuantity > 0 — перевірка оновлення значення Quantity.
        // - newQuantity = 0 — перевірка, що нульове значення дозволене (якщо вважається логічно припустимим).
        // - newQuantity < 0 — очікується ArgumentException.

        public void UpdatePrices(decimal newPriceZakup, decimal newPriceOpt, decimal newPriceProd)
        {
            if (newPriceZakup <= 0 || newPriceOpt <= 0 || newPriceProd <= 0)
                throw new ArgumentException("Ціни мають бути більше нуля.");

            Price_zakup = newPriceZakup;
            Price_opt = newPriceOpt;
            Price_prod = newPriceProd;
        }

        // Потребує таких тестових наборів:
        // - Усі ціни > 0 — перевірка оновлення цін.
        // - Будь-яка з цін = 0 або < 0 — очікується ArgumentException.
        // - Граничні значення типу decimal (наприклад, 0.0001) — перевірка округлень або точності, якщо важливо.
    }
}
