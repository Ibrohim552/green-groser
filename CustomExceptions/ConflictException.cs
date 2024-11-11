namespace GlobalExceptionHandler.CustomExceptions;

public class ConflictException : BaseException
{
    public ConflictException(string message) : base(message, 409)
    {
    }

    public ConflictException(string message, int statusCode) : base(message, statusCode)
    {
    }
}