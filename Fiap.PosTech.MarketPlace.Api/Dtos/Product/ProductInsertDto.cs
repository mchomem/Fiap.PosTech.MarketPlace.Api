namespace Fiap.PosTech.MarketPlace.Api.Dtos.Product;

/// <summary>
/// DTO de inserção para entidade produto.
/// </summary>
public record ProductInsertDto
{    
    /// <summary>
    /// Nome do produto.
    /// </summary>
    public required string Name { get; init; }
    
    /// <summary>
    /// Descrição do produto.
    /// </summary>
    public required string Description { get; init; }

    /// <summary>
    /// Código de barras do produto.
    /// </summary>
    public required string BarCode { get; init; }

    /// <summary>
    /// Preço do produto.
    /// </summary>
    public required decimal Price { get; init; }
    
    /// <summary>
    /// Estoque do produto.
    /// </summary>
    public required double Stock { get; init; }
}