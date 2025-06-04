namespace Locamobi_CRUD_Repositories.Entity
{
    public class ContratoEntity
    {
        public int CodContrato { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public int PrecoBase { get; set; }

        public int Veiculo_CodVeiculo { get; set; }

        public int Usuario_CodLoctar { get; set; }

        public int Usuario_CodLocdor { get; set; }
    }
}
