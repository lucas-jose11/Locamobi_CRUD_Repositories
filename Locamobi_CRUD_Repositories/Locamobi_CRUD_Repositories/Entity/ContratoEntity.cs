namespace Locamobi_CRUD_Repositories.Entity
{
    public class ContratoEntity
    {
        public int CodContrato { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public int PrecoBase { get; set; }

        public int VeiculoCodVeiculo { get; set; }

        public int UsuarioCodLoctar { get; set; }

        public int UsuarioCodLocdor { get; set; }
    }
}
