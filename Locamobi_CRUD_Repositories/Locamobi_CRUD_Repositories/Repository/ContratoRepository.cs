using Dapper;
using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.Entity;
using MeuPrimeiroCrud.Infrastructure;
using MySql.Data.MySqlClient;

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
                            VEICULO_CODVEICULO AS {nameof(ContratoEntity.VeiculoCodVeiculo)},
                            USUARIO_CODLOCTAR AS {nameof(ContratoEntity.UsuarioCodLoctar)},
                            USUARIO_CODLOCDOR AS {nameof(ContratoEntity.UsuarioCodLocdor)},
                      FROM MECANICO
                ";

                IEnumerable<ContratoEntity> contractList = await con.QueryAsync<ContratoEntity>(sql);
                return contractList;
            }



            throw new NotImplementedException();
        }





    }
}
