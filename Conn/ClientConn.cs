using cadastro_cliente.Model;
using cadastro_cliente.Service;
using System;

namespace cadastro_cliente.Conn
{
    public class ClientConn
    {
        public static void CadastrarClienteMenu(string connString)
        {
            ClientService clientService = new ClientService(connString);
            Client cliente = new Client();

            while (true)
            {
                try
                {
                    Console.WriteLine("\n-- Cadastro de Cliente --\n");
                    Console.Write("Digite -1 em qualquer campo para cancelar\n\n");

                    Console.Write("Digite o nome do cliente: ");
                    cliente.nome = Console.ReadLine() ?? string.Empty;

                    if (cliente.nome == "-1")
                    {
                        Console.WriteLine("Cadastro cancelado.");
                        break;
                    }

                    Console.Write("Digite o telefone do cliente: ");
                    cliente.telefone = Console.ReadLine() ?? string.Empty;

                    if (cliente.telefone == "-1")
                    {
                        Console.WriteLine("Cadastro cancelado.");
                        break;
                    }

                    Console.Write("Digite o limite de crédito: ");
                    cliente.limite_credito = Console.ReadLine() ?? string.Empty;

                    if (cliente.limite_credito == "-1")
                    {
                        Console.WriteLine("Cadastro cancelado.");
                        break;
                    }

                    //Mensagem de confirmação
                    var (sucesso, mensagem) = clientService.CadastrarCliente(cliente);

                    Console.WriteLine($"\n{mensagem}\n");

                    if (sucesso)
                    {
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        cliente = new Client(); // Limpa os dados para novo cadastro
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nErro inesperado: {ex.Message}");
                    Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                }
            }
        }
    }
}
