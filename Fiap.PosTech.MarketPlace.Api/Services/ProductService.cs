namespace Fiap.PosTech.MarketPlace.Api.Services;

/// <summary>
/// Implementação do serviço de produto.
/// </summary>
public class ProductService : IProductService
{
    private readonly IProductMemoryRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Construtor do serviço de produto.
    /// </summary>
    /// <param name="productRepository">O repositório de produtos.</param>
    /// <param name="mapper">O mapeador de objetos.</param>
    public ProductService(IProductMemoryRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Cria um novo produto.
    /// </summary>
    /// <param name="product">O produto a ser criado.</param>
    /// <returns>O produto criado.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ProductDto> CreateAsync(ProductInsertDto product)
    {
        var exists = await _productRepository.CheckIfExistsAsync(p => p.Name == product.Name);
        var newProduct = new Product(product.Name, product.Description, product.BarCode, product.Price, product.Stock);
        newProduct.CheckIfAlreadyExists(exists);
        newProduct.CheckIfStockIsNegative();
        var createdProduct = await _productRepository.CreateAsync(newProduct);

        return _mapper.Map<ProductDto>(createdProduct);
    }

    /// <summary>
    /// Deleta um produto existente pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do produto a ser excluído.</param>
    /// <returns>O produto excluído.</returns>
    public async Task<ProductDto> DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        product.CheckIfNotFound();
        var deletedProduct = await _productRepository.DeleteAsync(id);

        return _mapper.Map<ProductDto>(deletedProduct);
    }

    /// <summary>
    /// Recupera todos os produtos disponíveis.
    /// </summary>
    /// <returns>Uma lista de produtos.</returns>
    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    /// <summary>
    /// Recupera um produto pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do produto a ser recuperado.</param>
    /// <returns>O produto correspondente ao ID fornecido.</returns>
    public async Task<ProductDto> GetByIdAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        product.CheckIfNotFound();
        return _mapper.Map<ProductDto>(product);
    }

    /// <summary>
    /// Atualiza um produto existente pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do produto a ser atualizado.</param>
    /// <param name="product">Os dados do produto a serem atualizados.</param>
    /// <returns>O produto atualizado.</returns>
    public async Task<ProductDto> UpdateAsync(Guid id, ProductUpdateDto product)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);
        existingProduct.CheckIfNotFound();
        existingProduct.Update(product.Name, product.Description, product.BarCode, product.Price, product.Stock);
        var updatedProduct = await _productRepository.UpdateAsync(existingProduct);

        return _mapper.Map<ProductDto>(updatedProduct);
    }
}
