namespace Fiap.PosTech.MarketPlace.Api.Dtos.User;

/// <summary>
/// DTO representando a solicitação de login de um usuário, contendo o nome de usuário e a senha.
/// </summary>
public record UserLoginRequestDto
{
    /// <summary>
    /// Nome de usuário do usuário que está tentando fazer login.
    /// </summary>
    public required string Username { get; init; }

    /// <summary>
    /// Senha do usuário que está tentando fazer login.
    /// </summary>
    public required string Password { get; init; }
}
