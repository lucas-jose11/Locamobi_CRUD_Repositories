namespace Locamobi_CRUD_Repositories.Infrastructure
{
    public class Connection
    {
        public static string Get()
        {
            return "Server=localhost;Database=mydb;User=root;Password=root;";
        }
    }
}
