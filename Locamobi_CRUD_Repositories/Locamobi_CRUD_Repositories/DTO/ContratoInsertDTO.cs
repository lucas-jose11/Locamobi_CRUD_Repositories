
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
        
    }
}