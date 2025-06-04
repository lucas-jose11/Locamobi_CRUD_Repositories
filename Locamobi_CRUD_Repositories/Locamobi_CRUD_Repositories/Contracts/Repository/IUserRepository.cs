using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;

namespace Locamobi_CRUD_Repositories.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> GetById(int id);
        Task Insert(UserInsertDTO user);
        Task Delete (int id);
        Task Update(UserEntity user);
    }
}
