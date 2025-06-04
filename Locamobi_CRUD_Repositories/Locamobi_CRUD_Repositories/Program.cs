using Google.Protobuf.WellKnownTypes;
using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi_CRUD_Repositories.Repository;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Cmp;
using ZstdSharp;

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
            //faltou CODVEICULO
            Console.Write("Informe o modelo: ");
            veiculoInsert.MODELO = Console.ReadLine();

            Console.Write("Informe a marca: ");
            veiculoInsert.MARCA = Console.ReadLine();

            Console.Write("Informe o ano: ");
            veiculoInsert.ANO = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe a placa: ");
            veiculoInsert.PLACA = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe o cor: ");
            veiculoInsert.COR = Console.ReadLine();

            Console.Write("Informe o código da cidade: ");
            veiculoInsert.CIDADE_CODCID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe a classificação: | 1 Ecônomico | 2 Intermediário | 3 Premium |");
            int option = Convert.ToInt32(Console.ReadLine());
            veiculoInsert.CLASSIFIC = DeterminatorClassific(option);
           
            Console.Write("Informe o tipo: | 1 Carro | 2 Motocicleta |");
            int option2 = Convert.ToInt32(Console.ReadLine());
            veiculoInsert.TIPO = DeterminatorTipo(option2);

            IVeiculoRepository veiculoRepository = new VeiculoRepository();
            await veiculoRepository.Insert(veiculoInsert);
            Console.WriteLine("Veiculo cadastrado com sucesso");
        }

         static string DeterminatorClassific(int option)
         {

            if (option == 1)
                return "economico";

            else if (option == 2)
                return "intermediario";


            else if (option == 3)
                return "premium";

            else
                throw new ArgumentException($"Classificação não encontrada{option}"); 
   
         }

        static string DeterminatorTipo(int option2)
        {
            if (option2 == 1)
                return "carro";

            else if (option2 == 2)
                return "motocicleta";

            else
                throw new ArgumentException($"Tipo não encontrada{option2}");
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