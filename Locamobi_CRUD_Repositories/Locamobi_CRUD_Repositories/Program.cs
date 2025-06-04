using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi_CRUD_Repositories.Repository;

namespace MeuPrimeiroCrud
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Cadastro de Veiculo");
                    Console.WriteLine("Comandos \n");
                    Console.WriteLine("C - Create | R - Read | U - Update | D - Delete");
                    char op = Convert.ToChar(Console.ReadLine());

                    switch (op)
                    {
                        case 'C':
                            break;
                        case 'R':
                            break;
                        case 'U':
                            break;
                        case 'D':
                            break;
                        default:
                            Console.WriteLine("Error:");
                            break;
                    }

                    Console.WriteLine("Enter para continuar ");
                    Console.ReadLine();
                    Console.Clear();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex}");
            }

        }
    
        static async Task Read()
        {
            IVeiculoRepository veiculoRepository = new VeiculoRepository();
            IEnumerable<VeiculoEntity> 

        }



    }
}