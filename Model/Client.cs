namespace cadastro_cliente.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string telefone { get; set; } = string.Empty;
        public string limite_credito { get; set; } = string.Empty;
    }
}
