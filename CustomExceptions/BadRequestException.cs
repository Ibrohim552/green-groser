namespace GlobalExceptionHandler.CustomExceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string message) : base(message, 400)
    {
    }

    public BadRequestException(string message, int statusCode) : base(message, statusCode)
    {
    }
}