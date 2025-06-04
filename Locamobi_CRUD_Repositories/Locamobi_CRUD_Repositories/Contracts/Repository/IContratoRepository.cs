using Locamobi_CRUD_Repositories.Entity;

namespace Locamobi_CRUD_Repositories.Contracts.Repository
{
    public interface IContratoRepository
    {
        Task<IEnumerable<ContratoEntity>> GetAll(); // task pro Read


    }
}
