using Dapper;
using MySql.Data.MySqlClient;

namespace CRUD.Infrastructure
{
    public class Connection
    {
        protected string connectionString = "Server=localhost;Port=3307;Database=mydb;User=root;Password=root;";

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
