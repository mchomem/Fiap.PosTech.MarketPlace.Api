namespace Fiap.PosTech.MarketPlace.Api.Exceptions.Product;

/// <summary>
/// Exceção lançada quando um produto já existe no sistema.
/// </summary>
public class ProductAlreadyExistsException : BaseException
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ProductAlreadyExistsException"/> com a mensagem de erro fornecida.
    /// </summary>
    /// <param name="message">A mensagem de erro.</param>
    public ProductAlreadyExistsException(string message) : base(message) { }
}
