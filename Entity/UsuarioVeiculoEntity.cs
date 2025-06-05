namespace CRUD.Entity
{
    public class UsuarioVeiculoEntity
    {
        public int UsuarioId { get; set; }
        public int VeiculoId { get; set; }
        public string Documento { get; set; }

        public UsuarioVeiculoEntity(int usuarioId,int veiculoId, string documento) {
            UsuarioId = usuarioId;
            VeiculoId = veiculoId;
            Documento = documento;
        }
    }
}
