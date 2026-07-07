namespace Fiap.PosTech.MarketPlace.Api.Interfaces.Repository;
using System.Linq.Expressions;
/// <summary>
/// Interface para repositório de produtos.
/// </summary>
public interface IProductMemoryRepository
{
    /// <summary>
    /// Recupera todos os produtos disponíveis.
    /// </summary>
    /// <returns>Uma lista de produtos.</returns>
    Task<IEnumerable<Product>> GetAllAsync();
    
    /// <summary>
    /// Recupera um produto pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do produto.</param>
    /// <returns>O produto correspondente ao ID fornecido.</returns>
    Task<Product> GetByIdAsync(Guid id);
    
    /// <summary>
    /// Cria um novo produto.
    /// </summary>
    /// <param name="product">O produto a ser criado.</param>
    /// <returns>O produto criado.</returns>
    Task<Product> CreateAsync(Product product);

    /// <summary>
    /// Atualiza um produto existente.
    /// </summary>
    /// <param name="product">O produto a ser atualizado.</param>
    /// <returns>O produto atualizado.</returns>
    Task<Product> UpdateAsync(Product product);

    /// <summary>
    /// Exclui um produto pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do produto a ser excluído.</param>
    /// <returns>O produto excluído.</returns>
    Task<Product> DeleteAsync(Guid id);

    /// <summary>
    /// Verifica se um produto existe com base em uma condição especificada.
    /// </summary>
    /// <param name="predicate">A condição a ser verificada.</param>
    /// <returns>Verdadeiro se existir um produto que atenda à condição; caso contrário, falso.</returns>
    Task<bool> CheckIfExistsAsync(Expression<Func<Product, bool>> predicate);
}
