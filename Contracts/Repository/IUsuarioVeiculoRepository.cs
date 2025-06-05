using CRUD.DTO;
using CRUD.Entity;
using System.Reflection;

namespace CRUD.Contracts.Repository
{
    public interface IUsuarioVeiculoRepository
    {
        Task<IEnumerable<UsuarioVeiculoEntity>> GetAll();

        Task<UsuarioVeiculoEntity> GetById(int UsuarioId, int VeiculoId);

        Task Insert(UsuarioVeiculoInsertDTO item);

        Task Delete(int usuarioId, int veiculoId);

        Task Update(UsuarioVeiculoEntity item);
    }
}
