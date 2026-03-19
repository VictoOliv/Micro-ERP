using cadastro_cliente.Model;
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
            string query = "SELECT COUNT(1) FROM usuarios WHERE email = @u AND senha = @p";

            try
            {
                using NpgsqlConnection conn = new NpgsqlConnection(this.connString);
                conn.Open();
                using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("u", email);
                cmd.Parameters.AddWithValue("p", senha);

                object? result = cmd.ExecuteScalar();
                int count = result == null ? 0 : Convert.ToInt32(result);
                return count > 0;
            }
            catch (NpgsqlException)
            {
                return false;
            }
        }
    }
}