namespace Locamobi_CRUD_Repositories.Entity
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public int CityId { get; set; }

        public UserEntity() { }

        public UserEntity(int id, string name, string email, string password, string phoneNumber, string adress, int cityId) 
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Adress = adress;
            CityId = cityId;
        }
    }
}
