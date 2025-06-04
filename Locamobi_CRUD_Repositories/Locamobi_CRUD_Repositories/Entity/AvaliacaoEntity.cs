namespace Locamobi_CRUD_Repositories.Entity
{
    public class AvaliacaoEntity
    {
        public int CodAva { get; set; }
        public int Nota { get; set; }
        public string Coment { get; set; }
        public DateTime Data { get; set; }
        public int Veiculo_CodVeiculo { get; set; }
        public int QuantUso { get; set; }
    }
}
