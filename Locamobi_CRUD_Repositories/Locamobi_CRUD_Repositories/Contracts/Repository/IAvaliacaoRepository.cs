using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;

namespace Locamobi_CRUD_Repositories.Contracts.Repository
{
    public interface IAvaliacaoRepository
    {
        Task<IEnumerable<AvaliacaoEntity>> GetAll();
        Task<AvaliacaoEntity> GetById(int id);
        Task Insert(AvaliacaoInsertDTO avaliacao);
        Task Update(AvaliacaoEntity avaliacao);
        Task Delete(int id);
    }
}
