using cadastro_cliente.Model;
using Npgsql;

namespace cadastro_cliente.Repository
{
    public class ProductRepository
    {
        private readonly string connString;

        public ProductRepository(string connString)
        {
            this.connString = connString;
        }

        public bool CadastrarProduto(Product produto)
        {
            string query = "INSERT INTO produto (nome, preco, codigo) VALUES (@nome, @preco, @codigo)";

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(this.connString);
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nome", produto.nome ?? string.Empty);
                cmd.Parameters.AddWithValue("@preco", produto.preco);
                cmd.Parameters.AddWithValue("@codigo", produto.codigo ?? string.Empty);

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
