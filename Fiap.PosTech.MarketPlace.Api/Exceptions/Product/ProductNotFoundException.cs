namespace Fiap.PosTech.MarketPlace.Api.Exceptions.Product;

/// <summary>
/// Exceção lançada quando um produto não é encontrado.
/// </summary>
public class ProductNotFoundException : BaseException
{
    /// <summary>
    /// Construtor da exceção ProductNotFoundException.
    /// </summary>
    /// <param name="message">A mensagem de erro.</param>
    public ProductNotFoundException(string message = "Product not found.") : base(message) { }

    /// <summary>
    /// Construtor da exceção ProductNotFoundException com base no ID do produto.
    /// </summary>
    /// <param name="productId">O ID do produto não encontrado.</param>
    public ProductNotFoundException(Guid productId)
        : base($"Produto com ID {productId} não encontrado.") { }
}
