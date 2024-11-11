namespace GlobalExceptionHandler.CustomExceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string message = "Data not found") : base(message,404)
    {
    }

    public NotFoundException(string message, int statusCode) : base(message, statusCode)
    {
    }
}