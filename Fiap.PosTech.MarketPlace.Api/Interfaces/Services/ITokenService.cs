namespace Fiap.PosTech.MarketPlace.Api.Interfaces.Services;

/// <summary>
/// Interface que define os métodos de autenticação de usuários.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Gera um token de autenticação para o usuário com base no nome de usuário e senha fornecidos.
    /// </summary>
    /// <param name="userLoginRequestDto">Objeto contendo o nome de usuário e a senha do usuário.</param>
    /// <returns>Token de autenticação gerado.</returns>
    Task<string> GenerateTokenAsync(UserLoginRequestDto userLoginRequestDto);
}