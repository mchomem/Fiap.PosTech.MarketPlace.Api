namespace Fiap.PosTech.MarketPlace.Api.Middlewares;

/// <summary>
/// Middleware para tratamento de exceções não tratadas na aplicação.
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    /// <summary>
    /// Construtor do middleware de tratamento de exceções.
    /// </summary>
    /// <param name="logger">Logger para registrar erros.</param>
    /// <param name="next">Próximo middleware no pipeline.</param>
    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    /// <summary>
    /// Método que intercepta a requisição HTTP e trata exceções não tratadas.
    /// </summary>
    /// <param name="context">Contexto HTTP da requisição.</param>
    /// <returns>Uma tarefa representando a operação assíncrona.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro não tratado detectado pelo middleware");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        ApiResponse<string> response;
        int statusCode = 0;

        switch (exception)
        {
            case BaseException businessException:
                response = new ApiResponse<string>(businessException.Message, "Violação de regra de negócio", false);
                statusCode = (int)HttpStatusCode.BadRequest;
                break;

            default:
                response = new ApiResponse<string>($"Um erro inesperado ocorreu. Detalhes: {exception.Message}", "Internal server error.", false);
                statusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
