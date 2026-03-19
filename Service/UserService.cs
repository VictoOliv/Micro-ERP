using System;
using cadastro_cliente.Model;

namespace cadastro_cliente.Service
{
    public class UserService
    {
        public bool ValidationUser(User user)
        {

            if (string.IsNullOrWhiteSpace(user.email))
            {
                Console.WriteLine("E-mail é obrigatório");
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.senha))
            {
                Console.WriteLine("Senha é obrigatória");
                return false;
            }

            return true;
        }

    }
}
