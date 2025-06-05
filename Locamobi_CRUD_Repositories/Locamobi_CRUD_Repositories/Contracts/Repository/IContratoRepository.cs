using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;

namespace Locamobi_CRUD_Repositories.Contracts.Repository
{
    public interface IContratoRepository
    {
        Task<IEnumerable<ContratoEntity>> GetAll(); // task pro Read

        Task Insert(ContratoInsertDTO newContract);    // task pro Create

        Task Update(ContratoEntity contract); // task pro Update

        Task<ContratoEntity> GetById(int id); // task pra conseguir o id para o Update

        Task Delete(int id); // task pro Delete

    }
}
