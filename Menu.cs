using cadastro_cliente.Conn;
using cadastro_cliente.Model;
using cadastro_cliente.Repository;
using System;
namespace cadastro_cliente
{
    public class Menu
    {
        public static void Opcoes(string[] args)
        {
            string connString = "Host=localhost;Username=postgres;Password=postgres;Database=Challenger";

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
                        Console.WriteLine("Alterar conta logada selecionado.");
                        Login.Main([]);
                        break;
                    case "2":
                        Console.WriteLine("Cadastrar cliente selecionado.");
                        ClientConn.CadastrarClienteMenu(connString);
                        break;
                    case "3":
                        Console.WriteLine("Cadastrar Produto selecionado.");
                        ProductConn.CadastrarProdutoMenu(connString, 0);
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
