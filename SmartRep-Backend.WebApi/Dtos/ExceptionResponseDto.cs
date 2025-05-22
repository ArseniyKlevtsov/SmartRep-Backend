using System.Net;

namespace SmartRep_Backend.WebApi.Dtos;

public class ExceptionResponseDto(HttpStatusCode httpStatusCode, string message)
{
    public HttpStatusCode StatusCode { get; set; } = httpStatusCode;
    public string Message { get; set; } = message;
}
