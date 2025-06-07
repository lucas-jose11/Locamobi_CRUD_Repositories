namespace Locamobi_CRUD_Repositories.Entity
{
    public class VeiculoEntity
    {
        public int CODVEICULO { get; set; } // seria só por convenção, mas no C# seria CodVeiculo, Modelo, Marca, etc...
        public string MODELO { get; set; }
        public string MARCA { get; set; }
        public int ANO { get; set; }
        public string PLACA { get; set; }
        public string COR { get; set; }
        public int CIDADE_CODCID { get; set; }
        public string CLASSIFIC { get; set; }
        public string TIPO { get; set; }
        public int USUARIO_CODUSER { get; set; }

        public VeiculoEntity() { } // apaga isso aq, não usa construtor


    }
}
