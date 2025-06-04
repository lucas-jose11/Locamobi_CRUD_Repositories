using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi_CRUD_Repositories.Repository;

namespace MeuPrimeiroCrud
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu de Avaliação");
                Console.WriteLine("C - CREATE");
                Console.WriteLine("R - READ");
                Console.WriteLine("U - UPDATE");
                Console.WriteLine("D - DELETE");
                Console.Write("Escolha uma opção: ");
                char op = Console.ReadLine().ToUpper()[0];

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
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static async Task Read()
        {
            IAvaliacaoRepository avaliacaoRepository = new AvaliacaoRepository();
            IEnumerable<AvaliacaoEntity> avaliacaoList = await avaliacaoRepository.GetAll();

            foreach (AvaliacaoEntity avaliacao in avaliacaoList)
            {
                Console.WriteLine($"Id: {avaliacao.CodAva} - Nota: {avaliacao.Nota} - Comentário: {avaliacao.Coment} - Data: {avaliacao.Data:yyyy-MM-dd} - Veículo: {avaliacao.Veiculo_CodVeiculo} - Quantidade de uso: {avaliacao.QuantUso}");
            }
        }

        static async Task Create()
        {
            AvaliacaoInsertDTO avaliacao = new AvaliacaoInsertDTO();

            Console.WriteLine("Digite a nota:");
            avaliacao.Nota = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o comentário:");
            avaliacao.Coment = Console.ReadLine();

            Console.WriteLine("Digite a data (dd/MM/yyyy):");
            avaliacao.Data = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite o código do veículo:");
            avaliacao.Veiculo_CodVeiculo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantidade de uso:");
            avaliacao.QuantUso = int.Parse(Console.ReadLine());

            IAvaliacaoRepository repo = new AvaliacaoRepository();
            await repo.Insert(avaliacao);

            Console.WriteLine("Avaliação cadastrada com sucesso!");
        }

        static async Task Delete()
        {
            await Read();
            Console.Write("Digite o Id da avaliação que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IAvaliacaoRepository avaliacaoRepository = new AvaliacaoRepository();
            await avaliacaoRepository.Delete(id);

            Console.WriteLine("Avaliação deletada com sucesso!");
        }

        static async Task Update()
        {
            await Read();
            Console.Write("Digite o Id da avaliação que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            IAvaliacaoRepository avaliacaoRepository = new AvaliacaoRepository();
            AvaliacaoEntity avaliacaoAtual = await avaliacaoRepository.GetById(id);

            if (avaliacaoAtual == null)
            {
                Console.WriteLine("Avaliação não encontrada.");
                return;
            }

            Console.Write($"Nova nota (atual: {avaliacaoAtual.Nota}): ");
            string inputNota = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(inputNota))
                avaliacaoAtual.Nota = int.Parse(inputNota);

            Console.Write($"Novo comentário (atual: {avaliacaoAtual.Coment}): ");
            string inputComent = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(inputComent))
                avaliacaoAtual.Coment = inputComent;

            Console.Write($"Nova data (atual: {avaliacaoAtual.Data:dd/MM/yyyy}): ");
            string inputData = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(inputData))
                avaliacaoAtual.Data = DateTime.ParseExact(inputData, "dd/MM/yyyy", new System.Globalization.CultureInfo("pt-BR"));
            Console.Write($"Novo código do veículo (atual: {avaliacaoAtual.Veiculo_CodVeiculo}): ");

            string inputVeiculo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(inputVeiculo))
                avaliacaoAtual.Veiculo_CodVeiculo = int.Parse(inputVeiculo);

            Console.Write($"Nova quantidade de uso (atual: {avaliacaoAtual.QuantUso}): ");
            string inputUso = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(inputUso))
                avaliacaoAtual.QuantUso = int.Parse(inputUso);

            await avaliacaoRepository.Update(avaliacaoAtual);
            Console.WriteLine("Avaliação atualizada com sucesso!");
        }
    }
}

