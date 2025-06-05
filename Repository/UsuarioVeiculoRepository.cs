using Dapper;
using CRUD.Contracts.Repository;
using CRUD.DTO;
using CRUD.Entity;
using CRUD.Infrastructure;
using MySql.Data.MySqlClient;

namespace CRUD.Repository
{
    public class UsuarioVeiculoRepository : IUsuarioVeiculoRepository
    {
        public async Task<IEnumerable<UsuarioVeiculoEntity>> GetAll()
        {            
            Connection _connection = new Connection();            
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT
                           USUARIO_CODUSER AS {nameof(UsuarioVeiculoEntity.UsuarioId)},
                           VEICULO_CODVEICULO AS {nameof(UsuarioVeiculoEntity.VeiculoId)},
                           DOCUMENTO AS {nameof(UsuarioVeiculoEntity.Documento)}
                      FROM item_usuario_veiculo
                ";

                IEnumerable<UsuarioVeiculoEntity> documentList = await con.QueryAsync<UsuarioVeiculoEntity>(sql);
                return documentList;                   
            }            
        }

        public async Task<UsuarioVeiculoEntity> GetById(int usuarioId, int veiculoId)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                      SELECT
                           USUARIO_CODUSER AS {nameof(UsuarioVeiculoEntity.UsuarioId)},
                           VEICULO_CODVEICULO AS {nameof(UsuarioVeiculoEntity.VeiculoId)},
                           DOCUMENTO AS {nameof(UsuarioVeiculoEntity.Documento)} 
                      FROM item_usuario_veiculo 
                      WHERE USUARIO_CODUSER = @usuarioId 
                      AND VEICULO_CODVEICULO = @veiculoId
                ";

                UsuarioVeiculoEntity documentList = await con.QueryFirstAsync<UsuarioVeiculoEntity>(sql, new { usuarioId, veiculoId });
                return documentList;
            }
        }

        public async Task Insert(UsuarioVeiculoInsertDTO item)
        {
            Connection _connection = new Connection();
            string sql = @$"
                INSERT INTO item_usuario_veiculo
                (
                    USUARIO_CODUSER,
                    VEICULO_CODVEICULO,
                    DOCUMENTO
                ) 
                VALUES
                (
                    @UsuarioId,
                    @VeiculoId,
                    @Documento
                )
            ";

            await _connection.Execute(sql, item);            
        }


        public async Task Delete(int usuarioId, int veiculoId)
        {
            Connection _connection = new Connection();
            string sql = @$"
                DELETE FROM item_usuario_veiculo
                    WHERE USUARIO_CODUSER = @UsuarioId AND
                          VEICULO_CODVEICULO = @VeiculoId";
            await _connection.Execute(sql, new { usuarioId, veiculoId });            
        }


        public async Task Update(UsuarioVeiculoEntity item)
        {
            Connection _connection = new Connection();

            string sql = @"
                UPDATE item_usuario_veiculo
                   SET DOCUMENTO = @Documento
                 WHERE USUARIO_CODUSER = @UsuarioId AND
                       VEICULO_CODVEICULO = @VeiculoId
            ";

            await _connection.Execute(sql, item);

        }
    }
}
