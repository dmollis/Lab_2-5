using BudMayster.Classes;
using MySql.Data.MySqlClient;

namespace BudMayster_.Core.Classes
{
    public static class Categories
    {
        public static List<string> GetCategories()
        {
            List<string> categories = new List<string>();

            try
            {
                Material.openConnectionDB();
                string query = "SELECT name FROM temp_categories";

                using (MySqlCommand cmd = new MySqlCommand(query, Material.getConnection()))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(reader.GetString("name"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Помилка під час завантаження категорій: {ex.Message}");
            }
            finally
            {
                Material.closeConnectionDB();
            }

            return categories;
        }

        public static List<string> GetKontr()
        {
            List<string> kontr = new List<string>();

            try
            {
                Material.openConnectionDB();
                string query = "SELECT name FROM kontragents";

                using (MySqlCommand cmd = new MySqlCommand(query, Material.getConnection()))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kontr.Add(reader.GetString("name"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Помилка під час завантаження категорій: {ex.Message}");
            }
            finally
            {
                Material.closeConnectionDB();
            }

            return kontr;
        }
    }
}
