using BudMayster.Classes;
using MySql.Data.MySqlClient;
using System.Security.Cryptography.Pkcs;

namespace BudMayster_.Core.Classes
{
    public abstract class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Contact_info { get; set; }

        public Supplier(int id, string name, string contact_info)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва товару не може бути порожньою.");

            ID = id;
            Name = name;
            Contact_info = contact_info;
        }

        public static List<Supplier> GetSupplier()
        {
            List<Supplier> suppl = new List<Supplier>();

            try
            {
                Material.openConnectionDB();
                string query = "SELECT id, name, contact_info FROM suppliers";
                using (MySqlCommand cmd = new MySqlCommand(query, Material.getConnection()))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var supp = new ConcreteSupp(
                                reader.GetInt32("id"),
                                reader.GetString("name"),
                                reader.IsDBNull(reader.GetOrdinal("contact_info")) ? "" : reader.GetString("contact_info")
                            );

                            suppl.Add(supp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Помилка під час отримання постачальників: {ex.Message}");
            }
            finally
            {
                Material.closeConnectionDB();
            }
            return suppl;
        }
    }
}
