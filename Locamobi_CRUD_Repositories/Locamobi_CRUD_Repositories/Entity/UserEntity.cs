namespace Locamobi_CRUD_Repositories.Entity
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }


        public UserEntity(int id, string name, string email, string password, string phoneNumber, string address, int cityId) 
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Address = address;
            CityId = cityId;
        }
    }
}
