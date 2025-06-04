namespace MeuPrimeiroCrud
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                ChoseOption(Menu());
            }
        }


        static char Menu()
        {
            Console.WriteLine(">>>>>CRUD da tabela Contrato do Banco de Dados Locamobi<<<<<");
            Console.WriteLine("");
            Console.WriteLine("Escolha uma opção abaixo e escreva a letra correspondente:");
            Console.WriteLine("C - CREATE");
            Console.WriteLine("R - READ");
            Console.WriteLine("U - UPDATE");
            Console.WriteLine("D - DELETE");

            char op = Console.ReadLine().ToUpper()[0];
            return op;
        }


        static void ChoseOption(char op)
        {
            try
            {
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
                        throw new Exception("Opção inválida.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine($"Erro: {ex.Message}");
                Console.WriteLine("Escolha uma opção válida.");
                Console.WriteLine("Aperte QUALQUER TECLA para continuar");
                Console.WriteLine("--------------------------------------");
                Console.ReadKey();
            }
        }




        static async Task Create()
        {

        }


        static async Task Read()
        {

        }


        static async Task Update()
        {

        }


        static async Task Delete()
        {

        }
    }
}