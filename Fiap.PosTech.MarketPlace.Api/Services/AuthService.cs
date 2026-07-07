namespace Fiap.PosTech.MarketPlace.Api.Services;

/// <summary>
/// Classe responsável por implementar os métodos de autenticação de usuários.  
/// </summary>
public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;

    /// <summary>
    /// Construtor da classe AuthService, que recebe uma instância de ITokenService para gerar tokens de autenticação.
    /// </summary>
    /// <param name="tokenService">Instância de ITokenService utilizada para gerar tokens de autenticação.</param>
    public AuthService(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    /// <summary>
    /// Gera um token de autenticação para o usuário com base no nome de usuário e senha fornecidos.
    /// </summary>
    /// <param name="userLoginRequestDto">Objeto contendo o nome de usuário e a senha do usuário.</param>
    /// <returns>Token de autenticação gerado.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<string> GenerateTokenAsync(UserLoginRequestDto userLoginRequestDto)
    {
        var token = await _tokenService.GenerateTokenAsync(userLoginRequestDto);
        return token;
    }
}
