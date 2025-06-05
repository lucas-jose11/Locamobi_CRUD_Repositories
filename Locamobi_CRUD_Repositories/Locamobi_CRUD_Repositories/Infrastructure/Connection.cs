using Dapper;
using MySql.Data.MySqlClient;

namespace MeuPrimeiroCrud.Infrastructure
{
    public class Connection
    {
        protected string connectionString = "Server= ||| HOST ||| ;Database= ||| NOME DA DATABASE ||| ;User= ||| USER ||| ;Password= ||| SENHA ||| ;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public async Task<int> Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, obj);
            }
        }
    }
}