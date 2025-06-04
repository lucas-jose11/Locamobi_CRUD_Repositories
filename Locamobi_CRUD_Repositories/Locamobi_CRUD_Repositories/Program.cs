using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi_CRUD_Repositories.Repository;
using Mysqlx.Crud;

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
                            await Delete();
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
    

        public async Task Create()
        {
            VeiculoInsertDTO veiculoInsert = new VeiculoInsertDTO();
            
            //colocar um autoicrement aqui pra quando inserir novo veiculo adiconar ao codido auto.
            Console.Write("Informe o modelo: ");
            string modelo = Console.ReadLine();

            Console.Write("Informe a marca: ");
            string marca = Console.ReadLine();

            Console.Write("Informe o ano: ");
            string ano = Console.ReadLine();

            Console.Write("Informe a placa: ");
            string placa = Console.ReadLine();

            Console.Write("Informe o cor: ");
            string cor = Console.ReadLine();

            Console.Write("Informe o código da cidade: ");
            int codigoCidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe a classificação: | 1 Ecônomico | 2 Intermediário | 3 Premium |");
            Console.Write("Informe o tipo: | 1 Carro | 2 Motocicleta |");




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

        static async Task Delete()
        { 
            await Read();
            Console.WriteLine("Informe o código do veiculo que deseja excluir:");
            int codVe = Convert.ToInt32(Console.ReadLine());
            IVeiculoRepository veiculoRepository = new VeiculoRepository();
            await veiculoRepository.Delete(codVe);
            Console.WriteLine("Veiculo excluido com sucesso!");
        
        }



    }
}