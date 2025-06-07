using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;

namespace Locamobi_CRUD_Repositories.Contracts.Repository
{
    public interface IContratoRepository
    {
        Task<IEnumerable<ContratoEntity>> GetAll();

        Task Insert(ContratoInsertDTO newContract);

        Task Update(ContratoEntity contract);

        Task<ContratoEntity> GetById(int id); // task pra conseguir o id para o Update

        Task Delete(int id);

    }
}
