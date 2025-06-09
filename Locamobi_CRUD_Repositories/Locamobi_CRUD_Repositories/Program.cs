using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi_CRUD_Repositories.Repository;

namespace Locamobi_CRUD_Repositories
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Cadastro de usuário");
                Console.WriteLine("C - CREATE");
                Console.WriteLine("R - READ");
                Console.WriteLine("U - UPDATE");
                Console.WriteLine("D - DELETE");
                char op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case 'C':
                        await Create();
                        break;
                    case 'R':
                        await Read();
                        break;
                    case 'U':
                        await Update();
                        break;
                    case 'D':
                        await Delete();
                        break;
                }
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadKey();
                Console.Clear();
            }

        }
        static async Task Create()
        {
            UserInsertDTO user = new UserInsertDTO();

            Console.WriteLine("Insira o nome do usuário: ");
            user.Name = Console.ReadLine();
            Console.WriteLine("Insira o email do usuário: ");
            user.Email = Console.ReadLine();
            Console.WriteLine("Insira a senha do usuário: ");
            user.Password = Console.ReadLine();
            Console.WriteLine("Insira o número de telefone do usuário: ");
            user.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Insira o endereço do usuário: ");
            user.Address = Console.ReadLine();

            IUserRepository userRepository = new UserRepository();
            await userRepository.Insert(user);
            Console.WriteLine("Usuário inserido com sucesso!");
        }
        static async Task Read() {
            IUserRepository userRepository = new UserRepository();
            IEnumerable<UserEntity> userList =await userRepository.GetAll();
            foreach (UserEntity userEntity in userList)
            {
                Console.WriteLine(userEntity.Id);
                Console.WriteLine(userEntity.Name);
                Console.WriteLine(userEntity.Email);
                Console.WriteLine(userEntity.Password);
                Console.WriteLine(userEntity.PhoneNumber);
                Console.WriteLine(userEntity.Address);
                Console.WriteLine(userEntity.CityId);
                Console.WriteLine();
            }
        }
        static async Task Update() {
            await Read();

            Console.WriteLine("Digite o id do usuário que você deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            IUserRepository userRepository = new UserRepository();
            UserEntity user = await userRepository.GetById(id);
            
            UpdateProperty(user,"Name","Insira um novo nome para o usuário ou aperte enter para deixar inalterado.");
            UpdateProperty(user, "Email","Insira um novo email para o usuário ou aperte enter para deixar inalterado.");
            UpdateProperty(user,"Password","Insira uma nova senha para o usuário ou aperte enter para deixar inalterado.");
            UpdateProperty(user,"PhoneNumber","Insira um novo número de telefone para o usuário ou aperte enter para deixar inalterado.");
            UpdateProperty(user,"Address","Insira um novo endereço para o usuário ou aperte enter para deixar inalterado.");
            
            await userRepository.Update(user);
            Console.WriteLine("Usuário alterado com sucesso!");
        
        }
        static async Task Delete()
        {
            await Read();
            Console.WriteLine("Insira o id que você deseja deletar: ");
            int id = int.Parse(Console.ReadLine());
            IUserRepository userRepository = new UserRepository();
            await userRepository.Delete(id);
            Console.WriteLine("Usuário deletado com sucesso!");
        }

        static void UpdateProperty(UserEntity user, string propertyName, string prompt)
        {
            Console.WriteLine(prompt);
            string newValue = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newValue))
            {
                var property = typeof(UserEntity).GetProperty(propertyName); /* typeof: pega a lista de todas as propriedades
                de UserEntity, GetProperty pega a propriedade específica*/
                if (property != null && property.CanWrite) //property.CanWrite: se a propriedade tem get e set e não apenas get(se pode ser alterável)
                {
                    try
                    {
                        Type propType = property.PropertyType;

                        object convertedValue = Convert.ChangeType(newValue, propType);
                        property.SetValue(user, convertedValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($@"Erro ao converter valor para a propriedade {propertyName}: {ex.Message}");
                    }
                }
            }
        }
    }
}