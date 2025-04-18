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

        public Material(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

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

        public override string ToString()
        {
            return $"Назва: {Name}\n" +
                   $"Кількість на складі: {Quantity} шт.\n" +
                   $"Ціна закупівлі: {Price_zakup} ₴\n" +
                   $"Ціна опту: {Price_opt} ₴\n" +
                   $"Ціна продажу: {Price_prod} ₴\n";
        }

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
    }
}
