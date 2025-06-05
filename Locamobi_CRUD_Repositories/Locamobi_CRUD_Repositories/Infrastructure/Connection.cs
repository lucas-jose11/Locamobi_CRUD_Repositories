﻿using Dapper;
using MySql.Data.MySqlClient;

namespace MeuPrimeiroCrud.Infrastructure
{
    public class Connection
    {
        protected string connectionString = "Server=localhost;Database=locamobi;User=root;Password=root;";

        public MySqlConnection GetConnection() // conecta com o banco usando uma biblioteca
        {
            return new MySqlConnection(connectionString);
        }

        public async Task<int> Execute(string sql, object obj) // permite a execução de um código no banco de dados
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, obj);
            }
        }

    }
}