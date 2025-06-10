
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
            try
            {
                while (true)
                {
                    Console.WriteLine("Cadastro de Veiculo");
                    Console.WriteLine("Comandos \n");
                    Console.WriteLine("C - Create | R - Read | U - Update | D - Delete");
                    char op = Convert.ToChar(Console.ReadLine().ToUpper());

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
                            Console.WriteLine("OPÇÃO INVÁLIDA");
                            break;
                    }

                    Console.WriteLine("Enter para continuar ");
                    Console.ReadLine();
                    Console.Clear();

                }
            }

            catch (FormatException)
            {
                Console.WriteLine("ERRO OPÇÃO INVÁLIDA INFORME UM VALOR VÁLIDO");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"ERRO REINICIE O SISTEMA {ex.Message}");
            }

        }
    

        static async Task Create()
        {
            try
            {
                VeiculoInsertDTO veiculoInsert = new VeiculoInsertDTO();

                //USUARIO_CODUSER depende de uma FK estrangeira, retornar ao codigo para resolver

                Console.Write("Informe o modelo: ");
                veiculoInsert.MODELO = Console.ReadLine();

                Console.Write("Informe a marca: ");
                veiculoInsert.MARCA = Console.ReadLine();

                Console.Write("Informe o ano: ");
                veiculoInsert.ANO = Convert.ToInt32(Console.ReadLine());

                Console.Write("Informe a placa: ");
                veiculoInsert.PLACA = Console.ReadLine();

                Console.Write("Informe o cor: ");
                veiculoInsert.COR = Console.ReadLine();

                Console.Write("Informe o código da cidade: ");
                veiculoInsert.CIDADE_CODCID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Informe a classificação: | 1 Ecônomico | 2 Intermediário | 3 Premium |");
                int option = Convert.ToInt32(Console.ReadLine());
                veiculoInsert.CLASSIFIC = DeterminatorClassific(option);

                Console.WriteLine("Informe o tipo: | 1 Carro | 2 Motocicleta |");
                int option2 = Convert.ToInt32(Console.ReadLine());
                veiculoInsert.TIPO = DeterminatorTipo(option2);

                Console.WriteLine("Infomre seu código de usuário unico ID"); 
                veiculoInsert.USUARIO_CODUSER = Convert.ToInt32(Console.ReadLine());

                IVeiculoRepository veiculoRepository = new VeiculoRepository();
                await veiculoRepository.Insert(veiculoInsert);
                Console.WriteLine("Veiculo cadastrado com sucesso");
            }

            catch (FormatException)
            {
                Console.WriteLine("ERRO OPÇÃO INVÁLIDA INFORME UM VALOR VÁLIDO");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"ERRO REINICIE O SISTEMA {ex.Message}");
            }
        }

        static string DeterminatorClassific(int option) 
        {

            switch (option)
            {
                case 1:
                    return "economico";

                case 2:
                    return "intermediario";

                case 3:
                    return "premium";

                default:
                throw new ArgumentException($"Classificação não encontrada{option}"); 
                
            }
         }

        static string DeterminatorTipo(int option2)
        {
            switch (option2)
            {
                case 1:
                    return "carro";

                case 2:
                    return "motocicleta";

                default:
                    throw new ArgumentException($"Tipo não encontrada{option2}");
                  
            }
         
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

        static async Task Update()
        {
            try
            {

                await Read();

                Console.WriteLine("Informe o código do veiculo que deseja alterar");
                int codVeic = Convert.ToInt32(Console.ReadLine());

                IVeiculoRepository veiculoRepository = new VeiculoRepository();
                VeiculoEntity veiculoEntity = await veiculoRepository.GetByCodVeiculo(codVeic);

                Console.WriteLine($"Informe o novo modelo: _______ |Enter para salvar {veiculoEntity.MODELO}|"); 
                string modelo = UpdateString(Console.ReadLine(), veiculoEntity.MODELO);
                veiculoEntity.MODELO = modelo;

                Console.WriteLine($"Informe a nova marca: _______ |Enter para salvar {veiculoEntity.MARCA}|");
                string marca = UpdateString(Console.ReadLine(), veiculoEntity.MARCA);
                veiculoEntity.MARCA = marca;

                Console.WriteLine($"Informe o novo ano: _______ |Enter para salvar {veiculoEntity.ANO}|");
                int ano = UpdateInt(Convert.ToInt32(Console.ReadLine()), veiculoEntity.ANO); 
                veiculoEntity.ANO = ano;

                Console.WriteLine($"Informe a nova placa: _______ |Enter para salvar {veiculoEntity.PLACA}|");
                string placa = UpdateString(Console.ReadLine(), veiculoEntity.PLACA);
                veiculoEntity.PLACA = placa;

                Console.WriteLine($"Informe a nova cor: _______ |Enter para salvar {veiculoEntity.COR}|");
                string cor = UpdateString(Console.ReadLine(), veiculoEntity.COR);
                veiculoEntity.COR = cor;

                Console.WriteLine($"Informe o novo código do cidade: _______ |Enter para salvar {veiculoEntity.CIDADE_CODCID}|"); 
                int cidadeCod = UpdateInt(Convert.ToInt32(Console.ReadLine()), veiculoEntity.CIDADE_CODCID);
                veiculoEntity.CIDADE_CODCID = cidadeCod;


                Console.WriteLine($"Infomre a nova classificação: | 1 Ecônomico | 2 Intermediário | 3 Premium| Enter para salvar {veiculoEntity.CLASSIFIC}|");
                string classific = DeterminatorClassific(Convert.ToInt32(Console.ReadLine()));
                veiculoEntity.CLASSIFIC = classific;

                Console.WriteLine($"Infomre o novo tipo: | 1 Carro | 2 Motocicleta | Enter para salvar {veiculoEntity.TIPO}|");
                string tipo = DeterminatorTipo(Convert.ToInt32(Console.ReadLine()));
                veiculoEntity.TIPO = tipo;

                Console.WriteLine($"Informe o novo código do usuário: _______ |Enter para salvar {veiculoEntity.USUARIO_CODUSER}|"); 
                int usuarioCodigo = UpdateInt(Convert.ToInt32(Console.ReadLine()), veiculoEntity.USUARIO_CODUSER);
                veiculoEntity.USUARIO_CODUSER = usuarioCodigo;


                await veiculoRepository.Update(veiculoEntity);

                Console.WriteLine("Veiculo alterado com sucesso!"); 
            }

            catch (FormatException)
            {
                Console.WriteLine("ERRO DE LEITURA INSIRA UM VALOR VÁLIDO"); 
                                                                            
            }

            catch (Exception ex)
            {
                Console.WriteLine($"ERRO INESPERADO REINICIE O SISTEMA {ex.Message}");
            }


        }

        static int UpdateInt(int new_, int current) 
        {
            if (new_ != 0) 
                return new_;
            else
                return current;
        }

        static string UpdateString(string new_,string current )
        {
            if (new_ != string.Empty)
                return new_;
            else
                return current;
        }
        



        static async Task Delete()
        {
            try
            {
                await Read();
                Console.WriteLine("Informe o código do veiculo que deseja excluir:");
                int codVe = Convert.ToInt32(Console.ReadLine());
                IVeiculoRepository veiculoRepository = new VeiculoRepository();
                await veiculoRepository.Delete(codVe);
                Console.WriteLine("Veiculo excluido com sucesso!");
            }
            catch (FormatException)
            {
                Console.WriteLine("ERRO DE LEITURA INSIRA UM VALOR VALIDO");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"ERRO INESPERADO REINICIE O SISTEMA {ex.Message}");
            }

        }



    }
}