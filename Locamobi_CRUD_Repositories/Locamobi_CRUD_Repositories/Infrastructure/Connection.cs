using Dapper;
using MySql.Data.MySqlClient;

namespace MeuPrimeiroCrud.Infrastructure
{
    public class Connection
    {
        // test
        protected string connectionString = "Server= ||| HOST ||| ;Database=locamobi;User= ||| USER ||| ;Password= ||| SENHA ||| ;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

    }
}