using cadastro_cliente.Model;
using cadastro_cliente.Service;
using System;

namespace cadastro_cliente.Conn
{
    public class ProductConn
    {
        public static void CadastrarProdutoMenu(string connString, decimal v)
        {
            ProductService productService = new ProductService(connString);
            Product product = new Product();

            while (true)
            {
                try
                {
                    Console.WriteLine("\n-- Cadastro de Produto --\n");
                    Console.Write("Digite -1 em qualquer campo para cancelar\n\n");

                    Console.Write("Digite o nome do produto: ");
                    product.nome = Console.ReadLine() ?? string.Empty;

                    if (product.nome == "-1")
                    {
                        Console.WriteLine("Cadastro cancelado.");
                        break;
                    }

                    Console.Write("Digite o preco do produto: ");
                    product.preco = v;

                    Console.Write("Digite o código do produto: ");
                    product.codigo = Console.ReadLine() ?? string.Empty;

                    if (product.codigo == "-1")
                    {
                        Console.WriteLine("Cadastro cancelado.");
                        break;
                    }

                    //Mensagem de confirmação
                    (bool sucesso, string mensagem) = productService.CadastrarProduto(product);

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
                        product = new Product(); // Limpa os dados para novo cadastro
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
