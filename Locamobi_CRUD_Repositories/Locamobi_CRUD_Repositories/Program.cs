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
                            await Read();
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
            IEnumerable<VeiculoEntity> veiculoList = await veiculoRepository.GetAll();
            foreach (VeiculoEntity veiculo in veiculoList)
            {
                Console.WriteLine($"Codigo do veiculo: {veiculo.CODVEICULO}");
                Console.Write($"Modelo: {veiculo.MODELO} | ");
                Console.Write($"Marca: {veiculo.MARCA} | ");
                Console.Write($"Ano: {veiculo.ANO}  | ");
                Console.Write($"Placa: {veiculo.PLACA}  | ");
                Console.WriteLine($"Cor: {veiculo.COR}  | ");
                Console.Write($"Codigo da cidade: {veiculo.CIDADE_CODCID}   | ");
                Console.Write($"Classificação: {veiculo.CLASSIFIC}   | ");
                Console.Write($"Tipos: {veiculo.TIPO}   | ");
                Console.WriteLine($"Código do usúario: {veiculo.USUARIO_CODUSER}  | \n");
                Console.WriteLine("===================================================== \n");
            
            }

        }



    }
}