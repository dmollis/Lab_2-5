using MySql.Data.MySqlClient;

namespace BudMayster_.Core.Classes
{
    public sealed class Constants
    {
        private static readonly Constants instance = new Constants();

        private Constants() { }

        public static Constants Instance
        {
            get
            {
                return instance;
            }
        }

        public MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=M4rrra4ma_4;database=budmayster");
        public string connectDB = "server=localhost;port=3306;username=root;password=M4rrra4ma_4;database=budmayster";

    }
}
