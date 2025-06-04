using Dapper;
using Crudzin.Infrastructure;
using MySql.Data.MySqlClient;
using Crudzin.Entity;
using System.Collections.Concurrent;
using Crudzin.Contracts.Repository;
using Crudzin.Repository;
using Crudzin.DTO_;

namespace Crudzin
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Cadastro de cidades");
                Console.WriteLine("C - CREATE");
                Console.WriteLine("R - READ");
                Console.WriteLine("U - UPDATE");
                Console.WriteLine("D - DELETE");
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
                }

                Console.WriteLine("Pressione enter para continuas");
                Console.ReadLine();
                Console.Clear();

            }
        }

        static async Task Read()
        {
            ICidadeRepository cidadeRepository = new CidadeRepository();
            IEnumerable<CidadeEntity> cidadeList = await cidadeRepository.GetAllAsync();
            foreach (CidadeEntity cidade in cidadeList)
            {
                Console.WriteLine($@"Código da cidade: {cidade.CODCID}");
                Console.WriteLine($@"Nome da cidade: {cidade.NOMECID}");
                Console.WriteLine($@"UF: {cidade.UF}");
                Console.WriteLine($@"----------------------------------");
            }
        }

        static async Task Create()
        {
            CidadeInsertDTO cidade = new CidadeInsertDTO();

            Console.WriteLine("Digite o nome");
            cidade.NOMECID = Console.ReadLine();

            Console.WriteLine("Digite a UF");
            cidade.UF = Console.ReadLine();

            CidadeRepository cidadeRepository = new CidadeRepository();
            await cidadeRepository.Insert(cidade);

            await cidadeRepository.Insert(cidade);
            Console.WriteLine("Cidade cadastrada com sucesso");

        }

        static async Task Delete()
        {
            await Read();
            Console.WriteLine("Digite o código que deseja excluir");
            int codigo = int.Parse(Console.ReadLine());

            CidadeRepository cidadeRepository = new CidadeRepository();
            await cidadeRepository.Delete(codigo);
            Console.WriteLine("Cidade deletada com sucesso");
        }

        static async Task Update()
        {
            //Leio os a tabela
            await Read();
            //Escolhe o codigo
            Console.WriteLine("Digite o código que deseja atualizar");
            int codigo = int.Parse(Console.ReadLine());

            //Carrega o formulario preenchido
            ICidadeRepository cidadeRepository = new CidadeRepository();
            CidadeEntity cidade = await cidadeRepository.GetById(codigo);

            //Troca os valores do formulario
            Console.WriteLine($"Digite um novo nome para {cidade.NOMECID}, ou aperte enter para deixar assim");
            string nome = Console.ReadLine();
            if (nome != string.Empty)
            {
                cidade.NOMECID = nome;
            }

            Console.WriteLine($"Digite a nova UF para {cidade.UF}, ou aperte enter para deixar assim");
            string UF = Console.ReadLine();
            if (UF != string.Empty)
            {
                cidade.UF = UF;
            }

            await cidadeRepository.Update(cidade);

            Console.WriteLine(cidade.NOMECID);
            Console.WriteLine(cidade.UF);

        }
    }
}