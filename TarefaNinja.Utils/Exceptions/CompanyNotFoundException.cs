namespace TarefaNinja.Utils.Exceptions;

public class CompanyNotFoundException: Exception
{
    public CompanyNotFoundException()
    {

    }

    public CompanyNotFoundException(string message): base(message)
    {

    }

    public CompanyNotFoundException(string message, Exception inner): base(message, inner)
    {

    }
}
