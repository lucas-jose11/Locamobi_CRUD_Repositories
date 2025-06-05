using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi_CRUD_Repositories.Repository;

namespace MeuPrimeiroCrud
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Cadastro de cidade");
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
            user.Adress = Console.ReadLine();

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

            Console.WriteLine("Insira um novo nome para o usuário ou aperte enter para deixar inalterado: ");
            string newName = Console.ReadLine();
            
            if (newName != string.Empty)
            {
                user.Name = newName;
            }
            Console.WriteLine("Insira um novo email para o usuário ou aperte enter para deixar inalterado: ");
            string newEmail = Console.ReadLine();
            if (newEmail != string.Empty)
            {
                user.Email = newEmail;
            }
            Console.WriteLine("Insira uma nova senha para o usuário ou aperte enter para deixar inalterado: ");
            string newPassword = Console.ReadLine();
            if (newPassword != string.Empty)
            {
                user.Password = newPassword;
            }
            Console.WriteLine("Insira um novo número de telefone para o usuário ou aperte enter para deixar inalterado: ");
            string newPhoneNumber = Console.ReadLine();
            if (newPhoneNumber != string.Empty)
            {
                user.PhoneNumber = newPhoneNumber;
            }
            Console.WriteLine("Insira um novo endereço para o usuário ou aperte enter para deixar inalterado:");
            string newAddress = Console.ReadLine();
            if (newAddress != string.Empty)
            {
                user.Address = newAddress;
            }

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
    }
}