using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi_CRUD_Repositories.Repository;
using MeuPrimeiroCrud.Infrastructure;
using Mysqlx.Crud;

namespace MeuPrimeiroCrud
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                await ChooseOption(Menu()); //await para o async Main esperar terminar o ChooseOption e não usar a tecla para sair da função como próximo argumento
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

        static async Task ChooseOption(char op)
        {
            try
            {
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
            ContratoRepository contratoRepository = new ContratoRepository();
            Connection _connection = new Connection();


            Console.WriteLine("Digite a data de início do contrato (formato dd/mm/aaaa):");
            string dataInicio = Console.ReadLine();

            Console.WriteLine("Digite a data de término do contrato (formato dd/mm/aaaa):");
            string dataFim = Console.ReadLine();

            Console.WriteLine("Digite o preço da diária (apenas o número):");
            int precoBase = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o código do veículo:");
            int veiculo_CodVeiculo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o código do locatário:");
            int usuario_CodLoctar = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o código do locador:");
            int usuario_CodLocdor = int.Parse(Console.ReadLine());

            ContratoInsertDTO newContract = new ContratoInsertDTO(
                dataInicio,
                dataFim,
                precoBase,
                veiculo_CodVeiculo,
                usuario_CodLoctar,
                usuario_CodLocdor
            );

            await contratoRepository.Insert(newContract);

            Console.WriteLine("Contrato adicionado com sucesso!");
        }


        static async Task Read()
        {
            IContratoRepository contratoRepository = new ContratoRepository();
            IEnumerable<ContratoEntity> contractList = await contratoRepository.GetAll();
            foreach (ContratoEntity contract in contractList)
            {
                Console.WriteLine($"-----------------------");
                Console.WriteLine($"Código do Contrato: {contract.CodContrato};");
                Console.WriteLine($"Data Início: {contract.DataInicio};");
                Console.WriteLine($"Data Fim: {contract.DataFim};");
                Console.WriteLine($"Preço Base (diária): {contract.PrecoBase};");
                Console.WriteLine($"Veículo_Código Veículo (FK): {contract.Veiculo_CodVeiculo};");
                Console.WriteLine($"Código Usuário (locatário): {contract.Usuario_CodLoctar};");
                Console.WriteLine($"Código Usuário (locador): {contract.Usuario_CodLocdor}.");
                Console.WriteLine("");
            }

            Console.WriteLine("-----------------------------"); //arrumar pra n aparecer no Delete()
            Console.WriteLine("Aperte ENTER para voltar");
            Console.WriteLine("-----------------------------");
            Console.ReadLine();
        }


        static async Task Update()
        {

        }


        static async Task Delete()
        {
            ContratoRepository contratoRepository = new ContratoRepository();
            await Read();

            Console.WriteLine("----------------");
            Console.WriteLine("Qual o número do \"código do contrato\" da inserção que você quer deletar?");
            int idForDelete = int.Parse(Console.ReadLine());

            Console.WriteLine($"Tem certeza que quer deletar o contrato com o código {idForDelete}? S para sim e qualquer outra letra para não");
            char confirmationToDelete = Console.ReadLine().ToUpper()[0];

            if (confirmationToDelete == 'S')
                await contratoRepository.Delete(idForDelete)
            else
            {
                await contratoRepository.Delete(idForDelete);
            }
        }
    }
}