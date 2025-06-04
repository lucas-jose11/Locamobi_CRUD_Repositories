namespace Locamobi_CRUD_Repositories.DTO
{
    public class AvaliacaoInsertDTO
    {
        public int Nota { get; set; }
        public string Coment { get; set; }
        public DateTime Data { get; set; }
        public int Veiculo_CodVeiculo { get; set; }
        public int QuantUso { get; set; }
    }
}
