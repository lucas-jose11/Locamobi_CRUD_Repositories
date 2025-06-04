using Dapper;
using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi_CRUD_Repositories.Infrastructure;
using MySql.Data.MySqlClient;

namespace Locamobi_CRUD_Repositories.Repository
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly string _connectionString = Connection.Get();

        public async Task<IEnumerable<AvaliacaoEntity>> GetAll()
        {
            using var connection = new MySqlConnection(_connectionString);
            return await connection.QueryAsync<AvaliacaoEntity>("SELECT * FROM avaliacao");
        }

        public async Task<AvaliacaoEntity> GetById(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<AvaliacaoEntity>(
                "SELECT * FROM avaliacao WHERE CODAVA = @Id", new { Id = id });
        }

        public async Task Insert(AvaliacaoInsertDTO avaliacao)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.ExecuteAsync(@"
        INSERT INTO avaliacao (NOTA, COMENT, DATA, VEICULO_CODVEICULO, QUANTUSO)
        VALUES (@NOTA, @COMENT, @DATA, @VEICULO_CODVEICULO, @QUANTUSO)", avaliacao);
        }

        public async Task Update(AvaliacaoEntity avaliacao)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.ExecuteAsync(@"
        UPDATE avaliacao
        SET NOTA = @Nota,
            COMENT = @Coment,
            DATA = @Data,
            VEICULO_CODVEICULO = @Veiculo_CodVeiculo,
            QUANTUSO = @QuantUso
        WHERE CODAVA = @CodAva", avaliacao);
        }

        public async Task Delete(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM avaliacao WHERE CODAVA = @Id", new { Id = id });
        }

    }
}
