namespace Locamobi_CRUD_Repositories.DTO
{
    public class UserInsertDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public int CityId { get; set; }
    }
}
