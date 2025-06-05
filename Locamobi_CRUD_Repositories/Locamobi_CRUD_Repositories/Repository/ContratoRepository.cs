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
                 INSERT INTO CONTRATO (DATAINICIO, DATAFIM, PRECOBASE, VEICULO_CODVEICULO, USUARIO_CODLOCTAR, USUARIO_CODLOCDOR)
                    VALUES
                    (@DataInicio, @DataFim, @PrecoBase, @Veiculo_CodVeiculo, @Usuario_CodLoctar, @Usuario_CodLocdor)
            ";
        
            await _connection.Execute(sql, newContract);
        }

        public async Task Update(ContratoEntity contract)
        {
            Connection _connection = new Connection();

            string sql = @"
                UPDATE CONTRATO
                    SET 
                        DATAINICIO = @DataInicio,
                        DATAFIM = @DataFim,
                        PRECOBASE = @PrecoBase,
                        VEICULO_CODVEICULO = @Veiculo_CodVeiculo,
                        USUARIO_CODLOCTAR = @Usuario_CodLoctar,
                        USUARIO_CODLOCDOR = @Usuario_CodLocdor
                    WHERE CODCONTRATO = @codContrato
            ";

            await _connection.Execute(sql, contract);
        }

        public async Task<ContratoEntity> GetById(int codContrato) // usado no Update
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
                      WHERE CODCONTRATO = @codContrato
                ";

                ContratoEntity contrato = await con.QueryFirstAsync<ContratoEntity>(sql, new { codContrato });
                return contrato;
            }
        }

        public async Task Delete(int codContrato) // Delete
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
