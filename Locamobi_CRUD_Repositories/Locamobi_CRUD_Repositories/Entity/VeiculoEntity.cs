namespace Locamobi_CRUD_Repositories.Entity
{
    public class VeiculoEntity
    {
        public int CODVEICULO { get; set; }
        public string MODELO { get; set; }
        public string MARCA { get; set; }
        public int ANO { get; set; }
        public int PLACA { get; set; }
        public string COR { get; set; }
        public int CIDADE_CODCID { get; set; }
        public string CLASSIFIC { get; set; }
        public string TIPO { get; set; }
        public string USUARIO_CODUSER { get; set; }

        public VeiculoEntity(int codVeiculo, string modelo, string marca, int ano,
            int placa, string cor, int cidade_codCid, string classific, string tipo, string usuario_codUser)
        {
            CODVEICULO = codVeiculo;
            MODELO = modelo;
            MARCA = marca;
            ANO = ano;
            PLACA = placa;
            COR = cor;
            CIDADE_CODCID = cidade_codCid;
            CLASSIFIC = classific;
            TIPO = tipo;
            USUARIO_CODUSER = usuario_codUser;
        }


    }
}
