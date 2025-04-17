using BudMayster_.Core.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace BudMayster_.Core.Classes
{
    public class DatabaseConnection : IDatabaseConnection 
    {
        private readonly MySqlConnection _connection;

        public DatabaseConnection(MySqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
