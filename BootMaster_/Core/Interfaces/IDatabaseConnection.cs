using MySql.Data.MySqlClient;

namespace BudMayster_.Core.Interfaces
{
    public interface IDatabaseConnection
    {
        void OpenConnection(); 
        void CloseConnection();
        MySqlConnection GetConnection();
    }
}
