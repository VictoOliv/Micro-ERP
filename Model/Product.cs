namespace cadastro_cliente.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string nome { get; set; } = string.Empty;
        public decimal preco { get; set; }
        public string codigo { get; set; }
    }
}
