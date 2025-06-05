using Dapper;
using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using MeuPrimeiroCrud.Infrastructure;
using MySql.Data.MySqlClient;
using System.Diagnostics.Contracts;

namespace Locamobi_CRUD_Repositories.Repository
{
    public class ContratoRepository : IContratoRepository
    {

        public async Task<IEnumerable<ContratoEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                     SELECT CODCONTRATO AS {nameof(ContratoEntity.CodContrato)},
                            DATAINICIO AS {nameof(ContratoEntity.DataInicio)},
                            DATAFIM AS {nameof(ContratoEntity.DataFim)},
                            PRECOBASE AS {nameof(ContratoEntity.PrecoBase)},
                            VEICULO_CODVEICULO AS {nameof(ContratoEntity.Veiculo_CodVeiculo)},
                            USUARIO_CODLOCTAR AS {nameof(ContratoEntity.Usuario_CodLoctar)},
                            USUARIO_CODLOCDOR AS {nameof(ContratoEntity.Usuario_CodLocdor)}
                      FROM CONTRATO
                ";

                IEnumerable<ContratoEntity> contractList = await con.QueryAsync<ContratoEntity>(sql);
                return contractList;
            }
        } // Read

        public async Task Insert(ContratoInsertDTO newContract) // Create
        {
            Connection _connection = new Connection(); //pq aq não precisa do using pra GetConnection?
            string sql = @$"
                 INSERT INTO CONTRATO (DATAINICIO, DATAFIM, PRECOBASE, VEICULOCODVEICULO, USUARIOCODLOCTAR, VEICULOCODDOR)
                    VALUES
                    (@DataInicio, @DataFim, @PrecoBase, @VeiculoCodVeiculo, @UsuarioCodLoctar, @UsuarioCodLocdor)
            ";
        
            await _connection.Execute(sql, newContract);
        }

        public async Task Delete(int codContrato)
        {
            Connection _connection = new Connection();
            string sql = @"
                DELETE FROM CONTRATO
                    WHERE CODCONTRATO = @codContrato
            ";

            await _connection.Execute(sql, new { codContrato });
        }

       
    }
}
