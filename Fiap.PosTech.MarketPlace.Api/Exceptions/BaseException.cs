namespace Fiap.PosTech.MarketPlace.Api.Exceptions;

/// <summary>
/// Classe base para exceções personalizadas na aplicação.
/// </summary>
public abstract class BaseException : Exception
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="BaseException"/> com uma mensagem de erro especificada.
    /// </summary>
    /// <param name="message">A mensagem de erro.</param>
    protected BaseException(string message) : base(message) { }
}
