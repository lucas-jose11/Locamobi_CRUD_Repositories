using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;

namespace Locamobi_CRUD_Repositories.Contracts.Repository
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<VeiculoEntity>> GetAll();

        Task<VeiculoEntity> GetByCodVeiculo(int codVeiculo);

        Task Insert(VeiculoInsertDTO veiculoInsert);

        Task Update(VeiculoInsertDTO veiculoUpdate);

        Task Delete(int codVeiculo);


    }
}
