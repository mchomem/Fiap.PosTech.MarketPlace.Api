namespace Fiap.PosTech.MarketPlace.Api.Dtos.Product;

/// <summary>
/// DTO padrão para entidade produto.
/// </summary>
public record ProductDto
{
    /// <summary>
    /// Identificador único do produto.
    /// </summary>
    public required Guid Id { get; init; }

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
