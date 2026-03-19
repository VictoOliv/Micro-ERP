using cadastro_cliente.Model;
using cadastro_cliente.Service;
using System;
using cadastro_cliente.Repository;

namespace cadastro_cliente
{
    public class Login
    {
        public static void Main(string[] args)
        {
            User user = new User { senha = string.Empty };
            UserService userService = new UserService();

            string connString = "Host=localhost;Username=postgres;Password=postgres;Database=Challenger";
            UserRepository userRepo = new UserRepository(connString);

            while (true)
            {
                try
                {
                    Console.WriteLine("\n-- Login pedidos de vendas --\n");

                    Console.Write("Digite -1 no email e senha para sair");
                    Console.Write("\nDigite seu e-mail: ");
                    user.email = Console.ReadLine() ?? string.Empty;

                    Console.Write("Digite sua senha: ");
                    user.senha = Console.ReadLine() ?? string.Empty;

                    if (user.email == "-1" || user.senha == "-1")
                        break;

                    if (!userService.ValidationUser(user))
                    {
                        continue;
                    }

                    bool valid = userRepo.ValidateCredentials(user.email, user.senha);
                    if (valid)
                    {
                        Console.WriteLine("Login efetuado com sucesso.");
                        Menu.Opcoes(Array.Empty<string>());
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Usuário ou senha inválidos.");
                    }
                }
                catch (Exception exOuter)
                {
                    Console.WriteLine($"Erro inesperado: {exOuter.Message}");
                    continue;
                }
            }
        }
    }
}
                  
