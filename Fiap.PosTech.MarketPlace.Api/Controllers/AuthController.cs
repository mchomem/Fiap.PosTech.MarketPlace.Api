namespace Fiap.PosTech.MarketPlace.Api.Controllers;

/// <summary>
/// Controller responsável por gerenciar a autenticação de usuários.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    /// <summary>
    /// Construtor da classe AuthController, que recebe uma instância de IAuthService para gerenciar a autenticação de usuários.
    /// </summary>
    /// <param name="authService">Instância de IAuthService para gerenciar a autenticação de usuários.</param>
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Endpoint para autenticar um usuário e gerar um token de autenticação.
    /// </summary>
    /// <param name="userLoginRequestDto">Objeto contendo o nome de usuário e a senha do usuário.</param>
    /// <returns>Token de autenticação gerado.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginRequestDto)
    {
        var token = await _authService.GenerateTokenAsync(userLoginRequestDto);
        var response = new ApiResponse<string>(token);
        return Ok(response);
    }
}
