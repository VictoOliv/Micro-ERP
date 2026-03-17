using Npgsql;
using System;

namespace cadastro_cliente.Repository
{
    public class UserRepository
    {
        private string connString;

        public UserRepository(string connString)
        {
            this.connString = connString;
        }

        public bool ValidateCredentials(string email, string senha)
        {
            string connString = "Host=localhost;Username=postgres;Password=postgres;Database=Challenger";
            string query = "SELECT COUNT(1) FROM usuarios WHERE email = @u AND senha = @p";

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connString);
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("u", email);
                cmd.Parameters.AddWithValue("p", senha);

                object? result = cmd.ExecuteScalar();
                int count = result == null ? 0 : Convert.ToInt32(result);
                return count > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}