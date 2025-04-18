using BudMayster.Classes;
using BudMayster_.Core.Interfaces;
using MySql.Data.MySqlClient;

namespace BudMayster_.Core.Classes
{
    public static class Categories
    {
        public static List<string> GetCategories(IDatabaseConnection dbConnection)
        {
            List<string> categories = new List<string>();

            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT name FROM temp_categories";

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
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
                dbConnection.CloseConnection();
            }

            return categories;
        }

        public static List<string> GetKontr(IDatabaseConnection dbConnection)
        {
            List<string> kontr = new List<string>();

            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT name FROM kontragents";

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
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
                throw new Exception($"Помилка під час завантаження контрагентів: {ex.Message}");
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return kontr;
        }
    }
}
