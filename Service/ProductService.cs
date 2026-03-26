using cadastro_cliente.Model;
using cadastro_cliente.Repository;
using System;

namespace cadastro_cliente.Service
{
    public class ProductService
    {
        private readonly ProductRepository productRepository;

        public ProductService(string connString)
        {
            productRepository = new ProductRepository(connString);
        }

        public (bool sucesso, string mensagem) ValidateProduct(Product product)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(product.nome))
                {
                    return (false, "Nome é obrigatório");
                }

                if (decimal.IsNegative(product.preco))
                {
                    return (false, "Preço não pode ser negativo");
                }

                if (string.IsNullOrWhiteSpace(product.nome))
                {
                    return (false, "Nome é obrigatório");
                }

                return (true, "Validação concluída com sucesso");
            }
            catch (Exception ex)
            {
                return (false, $"Erro na validação: {ex.Message}");
            }
        }

        public (bool sucesso, string mensagem) CadastrarProduto(Product product)
        {
            try
            {
                var (valido, mensagem) = ValidateProduct(product);
                if (!valido)
                {
                    return (false, mensagem);
                }

                bool resultado = productRepository.CadastrarProduto(product);

                if (resultado)
                {
                    return (true, "Produto cadastrado com sucesso!");
                }
                else
                {
                    return (false, "Erro ao cadastrar produto no banco de dados");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Erro inesperado: {ex.Message}");
            }
        }
    }
}
