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




                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex}");
            }
         

        }
    }
}