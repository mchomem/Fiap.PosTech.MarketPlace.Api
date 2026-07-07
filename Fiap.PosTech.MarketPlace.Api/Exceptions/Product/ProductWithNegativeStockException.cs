namespace Fiap.PosTech.MarketPlace.Api.Exceptions.Product;

/// <summary>
/// Exceção lançada quando um produto possui estoque negativo.
/// </summary>
public class ProductWithNegativeStockException : BaseException
{
    /// <summary>
    /// Construtor da exceção ProductWithNegativeStockException.
    /// </summary>
    /// <param name="message">A mensagem de erro.</param>
    public ProductWithNegativeStockException(string message) : base(message) { }
}
