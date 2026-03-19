using cadastro_cliente.Model;
using Npgsql;

namespace cadastro_cliente.Repository
{
    public class ClientRepository
    {
        private readonly string? connString;

        public ClientRepository(string connString)
        {
            this.connString = connString;
        }

        public bool CadastrarCliente(Client cliente)
        {
            string query = "INSERT INTO cliente (nome, telefone, limite_credito) VALUES (@nome, @telefone, @limite_credito)";

            try
            {
                using NpgsqlConnection conn = new NpgsqlConnection(this.connString);
                conn.Open();
                using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nome", cliente.nome ?? string.Empty);
                cmd.Parameters.AddWithValue("@telefone", cliente.telefone ?? string.Empty);
                cmd.Parameters.AddWithValue("@limite_credito", decimal.TryParse(cliente.limite_credito, out var valor) ? valor : 0m);

                int linhasAfetadas = cmd.ExecuteNonQuery();
                return linhasAfetadas > 0;
            }
            catch (NpgsqlException)
            {
                return false;
            }
        }
    }
}
