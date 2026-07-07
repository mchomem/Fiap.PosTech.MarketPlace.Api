namespace Fiap.PosTech.MarketPlace.Api.Entities;

/// <summary>
/// Representa um produto no sistema.
/// </summary>
public class Product
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Product"/> com os valores fornecidos.
    /// </summary>
    /// <param name="name">Nome do produto.</param>
    /// <param name="description">Descrição do produto.</param>
    /// <param name="barCode">Código de barras do produto.</param>
    /// <param name="price">Preço do produto.</param>
    /// <param name="stock">Estoque do produto.</param>
    public Product(string name, string description, string barCode, decimal price, double stock)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        BarCode = barCode;
        Price = price;
        Stock = stock;
    }

    /// <summary>
    /// Identificador único do produto.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Nome do produto.
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Descrição do produto.
    /// </summary>
    public string Description { get; private set; }
    
    /// <summary>
    /// Código de barras do produto.
    /// </summary>
    public string BarCode { get; private set; }

    /// <summary>
    /// Preço do produto.
    /// </summary>
    public decimal Price { get; private set; }
    
    /// <summary>
    /// Estoque do produto.
    /// </summary>
    public double Stock { get; private set; }

    /// <summary>
    /// Atualiza os detalhes do produto com os valores fornecidos.
    /// </summary>
    /// <param name="name">Nome do produto.</param>
    /// <param name="description">Descrição do produto.</param>
    /// <param name="barCode">Código de barras do produto.</param>
    /// <param name="price">Preço do produto.</param>
    /// <param name="stock">Estoque do produto.</param>
    public void Update(string name, string description, string barCode, decimal price, double stock)
    {
        Name = name;
        Description = description;
        BarCode = barCode;
        Price = price;
        Stock = stock;
    }

    /// <summary>
    /// Verifica se o produto existe, lançando uma exceção caso não exista.
    /// </summary>
    /// <exception cref="ProductNotFoundException">Lançada se o produto não existir.</exception>
    public void CheckIfNotFound()
    {
        if (this is null)
            throw new ProductNotFoundException($"Produto com ID {Id} não encontrado.");
    }

    /// <summary>
    /// Verifica se o produto já existe, lançando uma exceção caso exista.
    /// </summary>
    /// <exception cref="ProductAlreadyExistsException">Lançada se o produto já existir.</exception>
    public void CheckIfAlreadyExists(bool exists)
    {
        if (exists)
            throw new ProductAlreadyExistsException($"Produto com ID {Id} já existe.");
    }

    /// <summary>
    /// Verifica se o estoque do produto é negativo, lançando uma exceção caso seja.
    /// </summary>
    /// <exception cref="ProductWithNegativeStockException">Lançada se o estoque do produto for negativo.</exception>
    public void CheckIfStockIsNegative()
    {
        if (Stock < 0)
            throw new ProductWithNegativeStockException($"Produto com ID {Id} possui estoque negativo.");
    }
}
