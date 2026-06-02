namespace LibraryManagement.Application.ResponseModel;

public class ResponseModel<T>
{
    public bool IsSucceeded { get; set; }
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public List<string> Errors { get; set; } = new();

    public static ResponseModel<T> Success(T data, string message = "Əməliyyat uğurlu oldu", int statusCode = 200)
        => new() { IsSucceeded = true, Data = data, Message = message, StatusCode = statusCode };

    public static ResponseModel<T> Success(string message = "Əməliyyat uğurlu oldu", int statusCode = 200)
        => new() { IsSucceeded = true, Message = message, StatusCode = statusCode };

    public static ResponseModel<T> Failure(string message, int statusCode = 400)
        => new() { IsSucceeded = false, Message = message, StatusCode = statusCode };

    public static ResponseModel<T> Failure(string message, List<string> errors, int statusCode = 400)
        => new() { IsSucceeded = false, Message = message, Errors = errors, StatusCode = statusCode };

    public static ResponseModel<T> ValidationFailure(List<string> errors)
        => new() { IsSucceeded = false, Message = "Validasiya xətası", Errors = errors, StatusCode = 422 };

    public static ResponseModel<T> NotFound(string message = "Tapılmadı")
        => new() { IsSucceeded = false, Message = message, StatusCode = 404 };

    public static ResponseModel<T> Unauthorized(string message = "İcazəniz yoxdur")
        => new() { IsSucceeded = false, Message = message, StatusCode = 401 };

    public static ResponseModel<T> Forbidden(string message = "Giriş qadağandır")
        => new() { IsSucceeded = false, Message = message, StatusCode = 403 };

    public static ResponseModel<T> ServerError(string message = "Daxili server xətası")
        => new() { IsSucceeded = false, Message = message, StatusCode = 500 };
}

public static class ResponseModel
{
    public static ResponseModel<T> Success<T>(T data, string message = "Əməliyyat uğurlu oldu", int statusCode = 200)
        => ResponseModel<T>.Success(data, message, statusCode);

    public static ResponseModel<T> Success<T>(string message = "Əməliyyat uğurlu oldu", int statusCode = 200)
        => ResponseModel<T>.Success(message, statusCode);

    public static ResponseModel<T> Failure<T>(string message, int statusCode = 400)
        => ResponseModel<T>.Failure(message, statusCode);

    public static ResponseModel<T> Failure<T>(string message, List<string> errors, int statusCode = 400)
        => ResponseModel<T>.Failure(message, errors, statusCode);

    public static ResponseModel<T> ValidationFailure<T>(List<string> errors)
        => ResponseModel<T>.ValidationFailure(errors);

    public static ResponseModel<T> NotFound<T>(string message = "Tapılmadı")
        => ResponseModel<T>.NotFound(message);

    public static ResponseModel<T> Unauthorized<T>(string message = "İcazəniz yoxdur")
        => ResponseModel<T>.Unauthorized(message);

    public static ResponseModel<T> Forbidden<T>(string message = "Giriş qadağandır")
        => ResponseModel<T>.Forbidden(message);

    public static ResponseModel<T> ServerError<T>(string message = "Daxili server xətası")
        => ResponseModel<T>.ServerError(message);
}
