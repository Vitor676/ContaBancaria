using Conta_Bancaria.Model;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Conta_Bancaria
{
    internal class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            int opcao = 1;

            Conta c1 = new Conta(1, 123, 1, "Vitor", 1000000.00M);

          /*  c1.Visualizar();
            c1.SetNumero(345);
            c1.Visualizar();

            c1.Sacar(1000);

            c1.Visualizar();

            c1.Depositar(5000);

            c1.Visualizar();

            ContaCorrente cc1 = new ContaCorrente(1, 123, 1, "Torviz", 1000.00M, 1000M);

            cc1.Visualizar();

            cc1.Sacar(20000000000.00M);

            cc1.Visualizar();

            cc1.Depositar(5000);

            cc1.Visualizar(); */

            ContaPoupanca cp1 = new ContaPoupanca(2, 123, 2, "Torviz", 80000000.00M, 25);

            cp1.Visualizar();

            cp1.Depositar(52);

            cp1.Visualizar();

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
                opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Criar Conta");
                        KeyPress();
                        break;
                    case 2:
                        Console.WriteLine("Listar todas as Contas");
                        KeyPress();
                        break;
                    case 3:
                        Console.WriteLine("Buscar Conta pelo Numero");
                        KeyPress();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar dados da Conta");
                        KeyPress();
                        break;
                    case 5:
                        Console.WriteLine("Apagar a Conta");

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
                    case 9:
                        Console.WriteLine("Sair");
                        KeyPress();
                        Sobre();
                        break; 
                    default:

                        Console.WriteLine("Opção Inválida!");
                        KeyPress();
                        break; 

                }
            }
        }
        static void KeyPress()
        {
            do
            {
                Console.Write("Pressione Enter para Continuar");
                consoleKeyInfo = Console.ReadKey();
            } while (consoleKeyInfo.Key != ConsoleKey.Enter);
        }
        static void Sobre()
        {
            Console.WriteLine("\n*********************************************************");
            Console.WriteLine("Projeto Desenvolvido por: Vitor Cesario ");
            Console.WriteLine("vitorsousa676@gmail.com");
            Console.WriteLine("github.com/Vitor676");
            Console.WriteLine("*********************************************************");
        }
    }
}
