using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi_CRUD_Repositories.Repository;
using MeuPrimeiroCrud.Infrastructure;

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
            Console.WriteLine("[0] - SAIR");

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
                Console.WriteLine("===========================================================");
                Console.WriteLine($"Erro: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Detalhes internos: {ex.InnerException.Message}");
                Console.WriteLine("Aperte QUALQUER TECLA para continuar");
                Console.WriteLine("===========================================================");
                Console.ReadKey();
            }
        }

        

        static async Task Create()
        {
            ContratoInsertDTO newContract = new ContratoInsertDTO();

            Console.WriteLine("=========================================================");
            string newStartDate = CreateProperty("Digite a data de início do contrato (formato aaaa-mm-dd):");
            string newEndDate = CreateProperty("Digite a data de término do contrato (formato aaaa-mm-dd):");
            string newBasePrice = CreateProperty("Digite o preço da diária (apenas o número):");
            string newVehicle_CodeVehicle = CreateProperty("Digite o código do veículo:");
            string newUser_CodeTenant = CreateProperty("Digite o código do locatário:");
            string newUser_CodeLandlord = CreateProperty("Digite o código do locador:");

            newContract.DataInicio = newStartDate;
            newContract.DataFim = newEndDate;
            newContract.PrecoBase = IntChecker(newBasePrice, "O preço da diária deve ser um número inteiro.");
            newContract.Veiculo_CodVeiculo = IntChecker(newVehicle_CodeVehicle, "O código do veículo deve ser um número inteiro.");
            newContract.Usuario_CodLoctar = IntChecker(newUser_CodeTenant, "O código de usuário do locatário deve ser um número inteiro.");
            newContract.Usuario_CodLocdor = IntChecker(newUser_CodeLandlord, "O código de usuário do locador deve ser um número inteiro.");

            ContratoRepository contratoRepository = new ContratoRepository();
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
            try
            {
                await Read();

                Console.WriteLine("==================================================================");
                Console.WriteLine("Me diga o códido do contrato que você quer alterar as informações:");
                int codContract = int.Parse(Console.ReadLine());

                Console.Clear();

                IContratoRepository contractRepository = new ContratoRepository();
                ContratoEntity contractToUpdate = await contractRepository.GetById(codContract);

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

                Console.WriteLine("Era esse o contrato para editar? Digite S para sim ou qualquer outra tecla para voltar");
                char confirmationToUpdate = Console.ReadLine().ToUpper()[0];

                if (confirmationToUpdate != 'S')
                    return;


                string newStartDate = UpdateProperty("Escreva a nova data de início do contrato ou aperte enter sem nada escrito para deixar assim, escreva no formato aaaa-mm-dd:");
                string newEndDate = UpdateProperty("Escreva a nova data de término do contrato ou aperte enter sem nada escrito para deixar assim, escreva no formato aaaa-mm-dd:");
                string newBasePrice = UpdateProperty("Escreva o novo preço diário ou aperte enter sem nada escrito para deixar assim:");
                string newVehicle_CodeVehicle = UpdateProperty("Escreva o código do veículo novo ou aperte enter sem nada escrito para deixar assim:");
                string newUser_CodeTenant = UpdateProperty("Escreva o código de usuário do novo locatário ou aperte enter sem nada escrito para deixar assim:");
                string newUser_CodeLandlord = UpdateProperty("Escreva o código de usuário do novo locador ou aperte enter sem nada escrito para deixar assim:");


                if (!String.IsNullOrEmpty(newStartDate))
                    contractToUpdate.DataInicio = newStartDate;

                if (!String.IsNullOrEmpty(newEndDate))
                    contractToUpdate.DataFim = newEndDate;
                
                if (!String.IsNullOrEmpty(newBasePrice))
                    contractToUpdate.PrecoBase = IntChecker(newBasePrice, "Digite um número inteiro para o novo preço diário.");

                if(!String.IsNullOrEmpty(newVehicle_CodeVehicle))
                    contractToUpdate.Veiculo_CodVeiculo = IntChecker(newVehicle_CodeVehicle, "O código do veículo novo deve ser um número inteiro.");
                
                if(!String.IsNullOrEmpty (newUser_CodeTenant))
                    contractToUpdate.Usuario_CodLoctar = IntChecker(newUser_CodeTenant, "O código de usuário do locatário deve ser um número inteiro.");
                
                if(!String.IsNullOrEmpty(newUser_CodeLandlord))
                    contractToUpdate.Usuario_CodLocdor = IntChecker(newUser_CodeLandlord, "O código do usuário do locador deve ser um número inteiro.");


                await contractRepository.Update(contractToUpdate);

                Console.WriteLine("Contrato alterado com suecesso!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}.\nVocê não escreveu num formato válido!");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message} ");
                return;
            }
            
            
        }


        static async Task Delete()
        {
            ContratoRepository contratoRepository = new ContratoRepository();
            await Read();

            Console.WriteLine("==========================================================================");
            Console.WriteLine("Qual o número do \"código do contrato\" da inserção que você quer deletar?");
            int idForDelete = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine($"Tem certeza que quer deletar o contrato com o código ||{idForDelete}||? S para sim e qualquer outra letra para não");
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


        static string CreateProperty(string prompt)
        {
            Console.WriteLine(prompt);
            string answer = Console.ReadLine();
            
            if(!String.IsNullOrEmpty(answer))
                return answer;

            throw new Exception("====================\nNão pode ser nulo.");
        }


        static string UpdateProperty(string prompt)
        {
            Console.WriteLine(prompt);
            string answer = Console.ReadLine();

            return answer;
        }

        static int IntChecker(string number, string error)
        {
            if (int.TryParse(number, out int numberChecked))
                return numberChecked;

            throw new Exception($"{error}");
        }



    }
}