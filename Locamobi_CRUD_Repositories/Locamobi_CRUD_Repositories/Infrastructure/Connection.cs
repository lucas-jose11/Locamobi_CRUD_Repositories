using Dapper;
using MySql.Data.MySqlClient;

namespace MeuPrimeiroCrud.Infrastructure
{
    public class Connection
    {
        protected string connectionString = "Server=servidor_teste;Database=locamobi;User=root;Password=toor;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

    }
}