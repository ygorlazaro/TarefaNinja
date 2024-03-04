namespace TarefaNinja.Utils.Exceptions;

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException() : base()
    {

    }

    public InvalidPasswordException(string message) : base(message)
    {

    }

    public InvalidPasswordException(string message, Exception inner) : base(message, inner)
    {

    }
}
