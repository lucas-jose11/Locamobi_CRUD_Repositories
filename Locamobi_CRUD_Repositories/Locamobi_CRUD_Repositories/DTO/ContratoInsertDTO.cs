namespace Locamobi_CRUD_Repositories.DTO
{
    public class ContratoInsertDTO
    {
        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public int PrecoBase { get; set; }

        public int Veiculo_CodVeiculo { get; set; }

        public int Usuario_CodLoctar { get; set; }

        public int Usuario_CodLocdor { get; set; }

        public ContratoInsertDTO(string dataInicio, string dataFim, int precoBase, int veiculo_CodVeiculo, int usuario_CodLoctar, int usuario_CodLocdor)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            PrecoBase = precoBase;
            Veiculo_CodVeiculo = veiculo_CodVeiculo;
            Usuario_CodLoctar = usuario_CodLoctar;
            Usuario_CodLocdor = usuario_CodLocdor;
        }
    }
}
