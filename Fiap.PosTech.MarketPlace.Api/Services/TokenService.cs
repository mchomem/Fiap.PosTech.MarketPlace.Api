namespace Fiap.PosTech.MarketPlace.Api.Services;

/// <summary>
/// Classe responsável por implementar o método de geração de token de autenticação para o usuário com base no nome de usuário e senha fornecidos.
/// </summary>
public class TokenService : ITokenService
{
    private readonly byte[] key = Encoding.ASCII.GetBytes("+WaLhdwMcCnW&cJW4a5hm^jFemE&?V?Y?z9eMdcN_X3DktLE7W9nS#Z2&vpakM6x");

    /// <summary>
    /// Gera um token de autenticação para o usuário com base no nome de usuário e senha fornecidos.
    /// </summary>
    /// <param name="userLoginRequestDto">Objeto contendo o nome de usuário e a senha do usuário.</param>
    /// <returns>Token de autenticação gerado.</returns>
    public async Task<string> GenerateTokenAsync(UserLoginRequestDto userLoginRequestDto)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(nameof(userLoginRequestDto.Username).ToLower(), userLoginRequestDto.Username),
                new Claim("startedIn", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff"))
            ]),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        string generatedToken = string.Empty;
        await Task.Run(() => generatedToken = tokenHandler.WriteToken(token));
        return generatedToken;
    }
}
