using Conta_Bancaria.Controller;
using Conta_Bancaria.Model;
using System.Diagnostics;
using System.Drawing;
using System.Linq.Expressions;

namespace Conta_Bancaria
{
    internal class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            int opcao = 1, agencia, tipo, aniversario, numero;
            string? titular;
            decimal saldo, limite;

            //objeto criado para acessar a classe ContaController (uma criação de um objeto novo de ContaController)
            ContaController contas = new();

            ContaCorrente cc1 = new ContaCorrente(contas.GerarNumero(), 123, 1, "Torviz", 1000.00M, 1000M);
            contas.Cadastrar(cc1);

            ContaPoupanca cp1 = new ContaPoupanca(contas.GerarNumero(), 123, 2, "Torviz", 80000000.00M, 25);
            contas.Cadastrar(cp1);

            while (true)


            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*****************************************************");
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Banco Santo André");

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("*****************************************************");
                Console.WriteLine("                                                     ");

                Console.WriteLine(" 1 - Criar Conta");
                Console.WriteLine(" 2 - Listar Todas as contas");
                Console.WriteLine(" 3 - Buscar Conta Pelo Número");
                Console.WriteLine(" 4 - Atualizar Dados da Conta");
                Console.WriteLine(" 5 - Apagar Conta");
                Console.WriteLine(" 6 - Saque Da Conta");
                Console.WriteLine(" 7 - Depositar");
                Console.WriteLine(" 8 - Transferir Valores entre as Contas ");
                Console.WriteLine(" 9 - Sair");

                Console.WriteLine("*****************************************************");
                Console.WriteLine("                  Digite a Sua Opção                 ");
                Console.WriteLine("                                                     ");
                Console.WriteLine("*****************************************************");
                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Digite um valor inteiro entre 1 e 9");
                    opcao = 0;
                    Console.ResetColor();
                }

                if (opcao == 9)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nBanco Santo André Vem Com Noix!");
                    Sobre();
                    Console.ResetColor();
                    System.Environment.Exit(0);
                }
                switch (opcao)
                {
                    case 1:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Criar Conta\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o Número da Agência: ");
                        agencia = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o Nome do Titular: ");
                        titular = Console.ReadLine();

                        //AQUI diz que se a variavel titular for nula(??) é para substituir por uma string empty(vazio), caso não for nula a variavel titular, é para passar o dado atribuido na variavel
                        titular ??= string.Empty;

                        do
                        {
                            Console.WriteLine("Digite o Tipo da Conta: ");
                            tipo = Convert.ToInt32(Console.ReadLine());

                        } while (tipo != 1 && tipo != 2);


                        Console.WriteLine("Digite o Saldo da Conta: ");
                        saldo = Convert.ToDecimal(Console.ReadLine());

                        switch (tipo)
                        {
                            case 1:
                                Console.WriteLine("Digite o Limite da Conta: ");
                                limite = Convert.ToDecimal(Console.ReadLine());

                                contas.Cadastrar(new ContaCorrente(contas.GerarNumero(), agencia, tipo, titular, saldo, limite));
                                break;
                            case 2:
                                Console.WriteLine("Digite o Aniversário da Conta: ");
                                aniversario = Convert.ToInt32(Console.ReadLine());

                                contas.Cadastrar(new ContaPoupanca(contas.GerarNumero(), agencia, tipo, titular, saldo, aniversario));
                                break;
                        }

                        KeyPress();
                        break;
                    case 2:
                        Console.WriteLine("Listar todas as Contas");
                        contas.ListarTodas();
                        KeyPress();
                        break;

                    case 3:
                        Console.WriteLine("Buscar Conta pelo Numero");

                        Console.WriteLine("Digite o número da conta");
                        numero = Convert.ToInt32(Console.ReadLine());


                        contas.ProcurarPorNumero(numero);

                        KeyPress();
                        break;

                    case 4:

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Atualizar dados da Conta\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        var conta = contas.BuscarNaCollection(numero);

                        if (conta is not null)
                        {
                            Console.WriteLine("Digite o Número da Agência: ");
                            agencia = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Digite o Nome do Titular: ");
                            titular = Console.ReadLine();

                            titular ??= string.Empty;

                            Console.WriteLine("Digite o Saldo da Conta: ");
                            saldo = Convert.ToDecimal(Console.ReadLine());

                            tipo = conta.GetTipo();

                            switch (tipo)
                            {
                                case 1:
                                    Console.WriteLine("Digite o Limite da Conta: ");
                                    limite = Convert.ToDecimal(Console.ReadLine());

                                    contas.Atualizar(new ContaCorrente(numero, agencia, tipo, titular, saldo, limite));
                                    break;
                                case 2:
                                    Console.WriteLine("Digite o dia do Aniversário da Conta: ");
                                    aniversario = Convert.ToInt32(Console.ReadLine());

                                    contas.Atualizar(new ContaPoupanca(numero, agencia, tipo, titular, saldo, aniversario));
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                            Console.ResetColor();
                        }
                        KeyPress();
                        break;

                    case 5:
                        Console.WriteLine("Apagar a Conta");

                        Console.WriteLine("Digite o número da conta");
                        numero = Convert.ToInt32(Console.ReadLine());

                        KeyPress();
                        break;

                    case 6:
                        Console.WriteLine("Saque");

                        KeyPress();
                        break;
                    case 7:
                        Console.WriteLine("Depósito");

                        KeyPress();
                        break;
                    case 8:
                        Console.WriteLine("Transferência entre Contas");

                        KeyPress();
                        break;



                    default:

                        Console.WriteLine("Opção Inválida!");
                        KeyPress();
                        break;

                }
            }
        }
        static void Sobre()
        {
            Console.WriteLine("\n*********************************************************");
            Console.WriteLine("Projeto Desenvolvido por: Vitor Cesario ");
            Console.WriteLine("vitorsousa676@gmail.com");
            Console.WriteLine("github.com/Vitor676");
            Console.WriteLine("*********************************************************");
        }
        static void KeyPress()
        {
            do
            {
                Console.Write("Pressione Enter para Continuar");
                consoleKeyInfo = Console.ReadKey();
            } while (consoleKeyInfo.Key != ConsoleKey.Enter);
        }
    }
}
