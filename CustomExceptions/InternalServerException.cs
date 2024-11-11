namespace GlobalExceptionHandler.CustomExceptions;

public class InternalServerException : BaseException
{
    public InternalServerException(string message) : base(message, 500)
    {
    }

    public InternalServerException(string message, int statusCode) : base(message, statusCode)
    {
    }
}