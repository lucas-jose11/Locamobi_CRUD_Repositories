namespace Locamobi_CRUD_Repositories.DTO
{
    public class VeiculoInsertDTO
    {
        public int CODVEICULO { get; set; } // o DTO n tem CODVEICULO, já que o Update não vai trocar o id (CODVEICULO) dele,
                                            // tvlz seja por isso a função do DTO, acessar apenas certas partes da Entidade, mas eu n tenho certeza absoluta
        public string MODELO { get; set; } // seria só por convenção, mas no C# seria CodVeiculo, Modelo, Marca, etc...
        public string MARCA { get; set; }
        public int ANO { get; set; }
        public string PLACA { get; set; }
        public string COR { get; set; }
        public int CIDADE_CODCID { get; set; }
        public string CLASSIFIC { get; set; }
        public string TIPO { get; set; }
        public int USUARIO_CODUSER { get; set; }

    }
}
