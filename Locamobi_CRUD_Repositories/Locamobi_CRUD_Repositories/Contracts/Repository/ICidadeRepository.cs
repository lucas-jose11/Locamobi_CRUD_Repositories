using Crudzin.DTO_;
using Crudzin.Entity;

namespace Crudzin.Contracts.Repository
{
    public interface ICidadeRepository
    {
        Task<IEnumerable<CidadeEntity>> GetAllAsync();
        Task<CidadeEntity> GetById(int codigo);
        Task Insert(CidadeInsertDTO cidade);
        Task Delete(int codigo);
        Task Update(CidadeEntity cidade);
    }
}
