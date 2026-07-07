namespace Fiap.PosTech.MarketPlace.Api.ProfileMappings;

/// <summary>
/// Classe responsável pelo mapeamento de perfis de entidades.
/// </summary>
public static class ProfileMapping
{
    /// <summary>
    /// Registra os mapeamentos de perfis de entidades.
    /// </summary>
    /// <param name="config">A configuração de mapeamento do Mapster.</param>
    public static void RegisterMappings(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductDto>().TwoWays();
        config.NewConfig<Product, ProductInsertDto>().TwoWays();
        config.NewConfig<Product, ProductUpdateDto>().TwoWays();
    }
}
