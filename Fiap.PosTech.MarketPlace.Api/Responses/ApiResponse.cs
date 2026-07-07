namespace Fiap.PosTech.MarketPlace.Api.Responses;

/// <summary>
/// Classe genérica para padronizar as respostas da API.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ApiResponse<T> where T : class
{
    /// <summary>
    /// Construtor da classe ApiResponse.
    /// </summary>
    /// <param name="data">Dados da resposta.</param>
    /// <param name="message">Mensagem da resposta.</param>
    /// <param name="success">Indica se a operação foi bem-sucedida.</param>
    public ApiResponse(T data, string message = "Operação realizada com sucesso.", bool success = true)
    {
        Data = data;
        Message = message;
        Success = success;
    }

    /// <summary>
    /// Obtém ou define os dados da resposta.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Obtém ou define um valor que indica se a operação foi bem-sucedida.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Obtém ou define a mensagem da resposta. 
    /// </summary>
    public string Message { get; set; }
}
