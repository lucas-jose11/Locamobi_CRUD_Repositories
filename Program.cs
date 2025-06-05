using CRUD.Contracts.Repository;
using CRUD.DTO;
using CRUD.Entity;
using CRUD.Repository;

namespace CRUD
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                string input = Console.ReadLine()?.Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(input)) continue;

                char op = input[0];

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

                    case 'S':
                        Console.WriteLine("Saindo do sistema...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

                Console.WriteLine("\nPressione Enter para continuar...");
                Console.ReadLine();
            }
        }

        private static async Task Create()
        {
            try
            {
                UsuarioVeiculoInsertDTO item = new UsuarioVeiculoInsertDTO();

                Console.WriteLine("Digite o ID do Usuário");
                item.UsuarioId = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o ID do Veículo");
                item.VeiculoId = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o documento");
                item.Documento = Console.ReadLine();

                IUsuarioVeiculoRepository usuarioVeiculoRepository = new UsuarioVeiculoRepository();
                await usuarioVeiculoRepository.Insert(item);

                Console.WriteLine("Documento inserido com sucesso!");
            }
            catch (FormatException)
            {
                Console.WriteLine("ID inválido! Certifique-se de digitar números inteiros.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir o documento: {ex.Message}");
            }
        }

        private static async Task Read()
        {
            try
            {
                IUsuarioVeiculoRepository usuarioVeiculoRepository = new UsuarioVeiculoRepository();
                IEnumerable<UsuarioVeiculoEntity> documentList = await usuarioVeiculoRepository.GetAll();

                foreach (UsuarioVeiculoEntity item in documentList)
                {
                    Console.WriteLine($"\nId do Usuario - {item.UsuarioId}");
                    Console.WriteLine($"Id do Veiculo - {item.VeiculoId}");
                    Console.WriteLine($"Numero de Documento - {item.Documento}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler os dados: {ex.Message}");
            }
        }

        private static async Task Update()
        {
            try
            {
                await Read();

                Console.WriteLine("Digite o ID do usuário que deseja alterar");
                int usuarioId = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o ID do veículo que deseja alterar");
                int veiculoId = int.Parse(Console.ReadLine());

                IUsuarioVeiculoRepository usuarioVeiculoRepository = new UsuarioVeiculoRepository();
                UsuarioVeiculoEntity item = await usuarioVeiculoRepository.GetById(usuarioId, veiculoId);

                if (item == null)
                {
                    Console.WriteLine("Relacionamento não encontrado.");
                    return;
                }

                Console.WriteLine($"Digite um novo número de documento para o proprietário com o ID {item.UsuarioId} que pertence ao veículo {item.VeiculoId} ou aperte enter para manter:");
                string newDocument = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newDocument))
                {
                    item.Documento = newDocument;
                }

                await usuarioVeiculoRepository.Update(item);
                Console.WriteLine("Documento alterado com sucesso!");
            }
            catch (FormatException)
            {
                Console.WriteLine("ID inválido! Digite apenas números.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o documento: {ex.Message}");
            }
        }

        private static async Task Delete()
        {
            try
            {
                await Read();

                Console.WriteLine("Digite o ID do usuário que deseja excluir");
                int usuarioId = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o ID do veículo que deseja excluir");
                int veiculoId = int.Parse(Console.ReadLine());

                IUsuarioVeiculoRepository usuarioVeiculoRepository = new UsuarioVeiculoRepository();
                await usuarioVeiculoRepository.Delete(usuarioId, veiculoId);

                Console.WriteLine("Cadastro de documento deletado com sucesso!");
            }
            catch (FormatException)
            {
                Console.WriteLine("ID inválido! Digite apenas números.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar o documento: {ex.Message}");
            }
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║      SISTEMA DE DOCUMENTAÇÃO VEICULAR     ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║    [C] - Cadastrar novo documento         ║");
            Console.WriteLine("║    [R] - Visualizar documentos            ║");
            Console.WriteLine("║    [U] - Atualizar documento existente    ║");
            Console.WriteLine("║    [D] - Remover documento                ║");
            Console.WriteLine("║                                           ║");
            Console.WriteLine("║    [S] - Sair do sistema                  ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("Escolha uma opção: ");
        }
    }
}