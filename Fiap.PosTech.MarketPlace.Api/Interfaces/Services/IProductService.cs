namespace Fiap.PosTech.MarketPlace.Api.Interfaces.Services;

/// <summary>
/// Interface de definição do contrato de métodos para o serviço de produto.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Obtém todos os produtos.
    /// </summary>
    /// <returns>Uma lista de produtos.</returns>
    Task<IEnumerable<ProductDto>> GetAllAsync();
    
    /// <summary>
    /// Obtém um produto pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do produto.</param>
    /// <returns>O produto correspondente ao ID.</returns>
    Task<ProductDto> GetByIdAsync(Guid id);
    
    /// <summary>
    /// Cria um novo produto.
    /// </summary>
    /// <param name="product">O produto a ser criado.</param>
    /// <returns>O produto criado.</returns>
    Task<ProductDto> CreateAsync(ProductInsertDto product);

    /// <summary>
    /// Atualiza um produto existente.
    /// </summary>
    /// <param name="id">O ID do produto a ser atualizado.</param>
    /// <param name="product">Os dados do produto a serem atualizados.</param>
    /// <returns>O produto atualizado.</returns>
    Task<ProductDto> UpdateAsync(Guid id, ProductUpdateDto product);

    /// <summary>
    /// Exclui um produto pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do produto a ser excluído.</param>
    /// <returns>O produto excluído.</returns>
    Task<ProductDto> DeleteAsync(Guid id);
}
