using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;

namespace Locamobi_CRUD_Repositories.Contracts.Repository
{
    public interface IContratoRepository
    {
        Task<IEnumerable<ContratoEntity>> GetAll(); // task pro Read

        Task Insert(ContratoInsertDTO newContract);    // task pro Create

        Task Delete(int id); // task pro Delete

        // Task GetById(int id); // task pra conseguir o id pra update

    }
}
