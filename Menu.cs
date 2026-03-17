using cadastro_cliente.Model;
using System;
namespace cadastro_cliente
{
    public class Menu
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n-- Menu Principal --\n");
                Console.WriteLine("Digite -1 pra sair");
                Console.WriteLine("1 - Alterar conta logada");
                Console.WriteLine("2 - Cadastrar Cliente");
                Console.WriteLine("3 - Cadastrar Produto");
                Console.WriteLine("4 - Cadastrar Venda");
                Console.Write("\nEscolha uma opção: ");

                string? input = Console.ReadLine()?.Trim();

                if (input == "-1")
                    break;

                switch (input)
                {
                    case "1":
                        // TODO: chamar método para alterar conta logada
                        Console.WriteLine("Alterar conta logada selecionado.");
                        break;
                    case "2":
                        // TODO: chamar método para cadastrar cliente
                        Console.WriteLine("Cadastrar Cliente selecionado.");
                        break;
                    case "3":
                        // TODO: chamar método para cadastrar produto
                        Console.WriteLine("Cadastrar Produto selecionado.");
                        break;
                    case "4":
                        // TODO: chamar método para cadastrar venda
                        Console.WriteLine("Cadastrar Venda selecionado.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
