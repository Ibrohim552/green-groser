namespace GlobalExceptionHandler.CustomExceptions;

public class BaseException : Exception
{
    public int StatusCode { get; set; }

    public BaseException(string message) : base(message)
    { }

    public BaseException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}