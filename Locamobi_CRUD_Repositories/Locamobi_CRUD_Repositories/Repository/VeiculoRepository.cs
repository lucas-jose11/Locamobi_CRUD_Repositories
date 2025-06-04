using Dapper;
using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using MeuPrimeiroCrud.Infrastructure;
using MySql.Data.MySqlClient;

namespace Locamobi_CRUD_Repositories.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        public async Task <IEnumerable<VeiculoEntity>> GetAll() 
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                        SELECT CODVEICULO AS {nameof(VeiculoEntity.CODVEICULO)},
                         MODELO AS {nameof(VeiculoEntity.MODELO)},
                            MARCA AS {nameof(VeiculoEntity.MARCA)},
                              ANO AS {nameof(VeiculoEntity.ANO)},
                                PLACA AS {nameof(VeiculoEntity.PLACA)},
                                  COR AS {nameof(VeiculoEntity.COR)},
                                    CIDADE_CODCID AS {nameof(VeiculoEntity.CIDADE_CODCID)},
                                      CLASSIFIC AS {nameof(VeiculoEntity.CLASSIFIC)},
                                        TIPO AS {nameof(VeiculoEntity.TIPO)},
                                          USUARIO_CODUSER {nameof(VeiculoEntity.USUARIO_CODUSER)}
                        FROM veiculo";

                IEnumerable<VeiculoEntity> veiculoList = await con.QueryAsync<VeiculoEntity>(sql);
                return veiculoList;
            }


        }



        public Task Delete(int codVeiculo)
        {
            throw new NotImplementedException();
        }

        public Task<VeiculoEntity> GetByCodVeiculo(int codVeiculo)
        {
            throw new NotImplementedException();
        }

        public Task Insert(VeiculoInsertDTO veiculoInsert)
        {
            throw new NotImplementedException();
        }

        public Task Update(VeiculoInsertDTO veiculoUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
