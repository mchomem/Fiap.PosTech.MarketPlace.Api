namespace Fiap.PosTech.MarketPlace.Api.Controllers;

/// <summary>
/// Controlador para entidade produto.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController: ControllerBase
{
    private readonly IProductService _productService;

    /// <summary>
    /// Construtor do controlador de produto.
    /// </summary>
    /// <param name="productService">O serviço de produto.</param>
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Recupera todos os produtos disponíveis.
    /// </summary>
    /// <returns>Uma lista de produtos.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllAsync();
        var reponse = new ApiResponse<IEnumerable<ProductDto>>(products);
        return Ok(reponse);
    }

    /// <summary>
    /// Recupera um produto pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do produto.</param>
    /// <returns>O produto correspondente ao ID fornecido.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);
        var response = new ApiResponse<ProductDto>(product);
        return Ok(response);
    }

    /// <summary>
    /// Cria um novo produto.
    /// </summary>
    /// <param name="product">O produto a ser criado.</param>
    /// <returns>O produto criado.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductInsertDto product)
    {
        var createdProduct = await _productService.CreateAsync(product);        
        var response = new ApiResponse<ProductDto>(createdProduct);
        return Ok(response);
    }

    /// <summary>
    /// Atualiza um produto existente.
    /// </summary>
    /// <param name="id">O ID do produto a ser atualizado.</param>
    /// <param name="product">Os dados do produto a serem atualizados.</param>
    /// <returns>O produto atualizado.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] ProductUpdateDto product)
    {
        var updatedProduct = await _productService.UpdateAsync(id, product);
        var response = new ApiResponse<ProductDto>(updatedProduct);
        return Ok(response);
    }

    /// <summary>
    /// Exclui um produto existente pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do produto a ser excluído.</param>
    /// <returns>Indica se o produto foi excluído com sucesso.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
    {
        var deleted = await _productService.DeleteAsync(id);
        var response = new ApiResponse<ProductDto>(deleted);
        return Ok(response);
    }
}
