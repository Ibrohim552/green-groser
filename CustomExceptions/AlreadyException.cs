namespace GlobalExceptionHandler.CustomExceptions;

public class AlreadyException : BaseException
{
    public AlreadyException(string message = "Already exist") : base(message,409)
    { }

    public AlreadyException(string message, int statusCode) : base(message, statusCode)
    { }
}