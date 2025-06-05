using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi_CRUD_Repositories.Repository;
using MeuPrimeiroCrud.Infrastructure;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Diagnostics.Contracts;

namespace MeuPrimeiroCrud
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear(); // tem pelo menos uma vez que ele vem pra cá e não passaria pelo Clear no ChooseOption
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

                Console.WriteLine("-----------------------------"); 
                Console.WriteLine("Aperte ENTER para voltar");
                Console.WriteLine("-----------------------------");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine($"Erro: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Detalhes internos: {ex.InnerException.Message}");
                Console.WriteLine("Aperte QUALQUER TECLA para continuar");
                Console.WriteLine("--------------------------------------");
                Console.ReadKey();
            }
        }



        static async Task Create() // falta fazer a tratativa
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
        }


        static async Task Update() // falta fazer a tratativa
        {
            await Read();

            Console.WriteLine("-------------");
            Console.WriteLine("Me diga o códido do contrato que você quer alterar as informações:");
            int codContract = int.Parse(Console.ReadLine());

            Console.Clear();

            IContratoRepository contractRepository = new ContratoRepository();
            ContratoEntity contractToUpdate = await contractRepository.GetById( codContract );
            
            Console.WriteLine($@"-------------------
Código do Contrato: {contractToUpdate.CodContrato};
Data Início: {contractToUpdate.DataInicio};
Data Fim: {contractToUpdate.DataFim};
Preço Base (diária): {contractToUpdate.PrecoBase}
Veículo_Código Veículo (FK): {contractToUpdate.Veiculo_CodVeiculo};
Código Usuário (locatário): {contractToUpdate.Usuario_CodLoctar};
Código Usuário (locador): {contractToUpdate.Usuario_CodLocdor}.
-------------------
            ");
           
            Console.WriteLine("");

            Console.WriteLine("Era esse o contrato para editar? S para sim ou qualquer outra tecla para voltar");
            char confirmationToUpdate = Console.ReadLine().ToUpper()[0];

            if (confirmationToUpdate != 'S')
                return;

            Console.WriteLine("Escreva a nova data de início do contrato ou escreva a atual para deixar assim, escreva no formato aaaa--mm-dd:"); // aranjar um jeito de editar apenas os campos que quer, mas fácil de passar por isso
            string newStartDate = Console.ReadLine();

            Console.WriteLine("Escreva a nova data de término do contrato ou escreva a atual para deixar assim, escreva no formato aaaa--mm-dd:");
            string newEndDate = Console.ReadLine();

            Console.WriteLine("Escreva o novo preço diário ou escreva o atual para deixar assim:");
            int newBasePrice = int.Parse(Console.ReadLine());

            Console.WriteLine("Escreva o código do veículo novo ou escreva o atual para deixar assim:");
            int newVehicle_CodeVehicle = int.Parse(Console.ReadLine());

            Console.WriteLine("Escreva o código de usuário do novo locatário ou escreva o atual para deixar assim:");
            int newUser_CodeTenant = int.Parse(Console.ReadLine());

            Console.WriteLine("Escreva o código de usuário do novo locador ou escreva o atual para deixar assim:");
            int newUser_CodeLandlord = int.Parse(Console.ReadLine());

            contractToUpdate.DataInicio = newStartDate;
            contractToUpdate.DataFim = newEndDate;
            contractToUpdate.PrecoBase = newBasePrice;
            contractToUpdate.Veiculo_CodVeiculo = newVehicle_CodeVehicle;
            contractToUpdate.Usuario_CodLoctar = newUser_CodeTenant;
            contractToUpdate.Usuario_CodLocdor = newUser_CodeLandlord;

            await contractRepository.Update(contractToUpdate);

            Console.WriteLine("Contrato alterado com suecesso!");
        }


        static async Task Delete() // falta fazer a tratativa, se precisar
        {
            ContratoRepository contratoRepository = new ContratoRepository();
            await Read();

            Console.WriteLine("----------------");
            Console.WriteLine("Qual o número do \"código do contrato\" da inserção que você quer deletar?");
            int idForDelete = int.Parse(Console.ReadLine());

            Console.WriteLine($"Tem certeza que quer deletar o contrato com o código {idForDelete}? S para sim e qualquer outra letra para não");
            char confirmationToDelete = Console.ReadLine().ToUpper()[0];

            if (confirmationToDelete == 'S')
            {
                await contratoRepository.Delete(idForDelete);
                Console.WriteLine("");
                Console.WriteLine("Contrato deletado com sucesso!");
            }
            else
            {
                Console.Clear();
                await Delete();
            }
        }
    }
}