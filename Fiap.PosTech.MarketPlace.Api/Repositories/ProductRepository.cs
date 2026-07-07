namespace Fiap.PosTech.MarketPlace.Api.Repositories;

/// <summary>
/// Repositório para entidade produto.
/// </summary>
public class ProductMemoryRepository : IProductMemoryRepository
{
    private readonly List<Product> dbContext;

    /// <summary>
    /// Inicializa uma nova instância do repositório de produtos.
    /// </summary>
    public ProductMemoryRepository()
    {
        dbContext = new List<Product>();
    }

    /// <summary>
    /// Cria um novo produto no repositório.
    /// </summary>
    /// <param name="product">O produto a ser criado.</param>
    /// <returns>O produto criado.</returns>
    public async Task<Product> CreateAsync(Product product)
    {
        dbContext.Add(product);
        return await Task.FromResult(product);
    }

    /// <summary>
    /// Deleta um produto existente pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do produto a ser deletado.</param>
    /// <returns>O produto deletado.</returns>
    public async Task<Product> DeleteAsync(Guid id)
    {
        var product = dbContext.FirstOrDefault(p => p.Id == id);
        dbContext.Remove(product!);        
        return await Task.FromResult(product!);
    }

    /// <summary>
    /// Recupera todos os produtos disponíveis no repositório.
    /// </summary>
    /// <returns>Uma lista de produtos.</returns>
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = dbContext.AsEnumerable();
        return await Task.FromResult(products);
    }

    /// <summary>
    /// Recupera um produto pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do produto.</param>
    /// <returns>O produto correspondente ao ID fornecido.</returns>
    public async Task<Product> GetByIdAsync(Guid id)
    {
        var product = dbContext.FirstOrDefault(p => p.Id == id);
        return await Task.FromResult(product!);
    }

    /// <summary>
    /// Atualiza um produto existente no repositório.
    /// </summary>
    /// <param name="product">O produto a ser atualizado.</param>
    /// <returns>O produto atualizado.</returns>
    public async Task<Product> UpdateAsync(Product product)
    {
        dbContext.Remove(dbContext.FirstOrDefault(p => p.Id == product.Id)!);
        dbContext.Add(product);
        return await Task.FromResult(product);
    }

    /// <summary>
    /// Verifica se um produto existe com base em uma condição especificada.
    /// </summary>
    /// <param name="predicate">A condição a ser verificada.</param>
    /// <returns>Verdadeiro se existir um produto que atenda à condição; caso contrário, falso.</returns>
    public async Task<bool> CheckIfExistsAsync(Expression<Func<Product, bool>> predicate)
    {
        var exists = dbContext.AsQueryable().Any(predicate);
        return await Task.FromResult(exists);
    }
}
