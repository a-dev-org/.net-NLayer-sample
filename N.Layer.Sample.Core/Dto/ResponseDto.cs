using System.Net;

namespace N.Layer.Sample.Core.Dto;

public record ResponseDto<T>(
    T Content,
    bool IsSuccess = false,
    HttpStatusCode Code = HttpStatusCode.InternalServerError,
    string? ErrorMessage = null);