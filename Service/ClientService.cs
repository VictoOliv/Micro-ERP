using cadastro_cliente.Model;
using cadastro_cliente.Repository;
using System;

namespace cadastro_cliente.Service
{
    public class ClientService
    {
        private readonly ClientRepository clientRepository;

        public ClientService(string connString)
        {
            clientRepository = new ClientRepository(connString);
        }

        public (bool sucesso, string mensagem) ValidateClient(Client client)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(client.nome))
                {
                    return (false, "Nome é obrigatório");
                }

                if (string.IsNullOrWhiteSpace(client.telefone))
                {
                    return (false, "Telefone é obrigatório");
                }

                if (string.IsNullOrWhiteSpace(client.limite_credito))
                {
                    return (false, "Limite de crédito é obrigatório");
                }

                if (!decimal.TryParse(client.limite_credito, out var limite))
                {
                    return (false, "Limite de crédito deve ser um valor numérico válido");
                }

                if (limite < 0)
                {
                    return (false, "Limite de crédito não pode ser negativo");
                }

                return (true, "Validação concluída com sucesso");
            }
            catch (Exception ex)
            {
                return (false, $"Erro na validação: {ex.Message}");
            }
        }

        public (bool sucesso, string mensagem) CadastrarCliente(Client client)
        {
            try
            {
                var (valido, mensagem) = ValidateClient(client);
                if (!valido)
                {
                    return (false, mensagem);
                }

                bool resultado = clientRepository.CadastrarCliente(client);

                if (resultado)
                {
                    return (true, "Cliente cadastrado com sucesso!");
                }
                else
                {
                    return (false, "Erro ao cadastrar cliente no banco de dados");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Erro inesperado: {ex.Message}");
            }
        }
    }
}
    