namespace TarefaNinja.Utils.Exceptions;

public class CompanyInfoNotInformedException: Exception
{
    public CompanyInfoNotInformedException()
    {

    }

    public CompanyInfoNotInformedException(string message): base(message)
    {

    }

    public CompanyInfoNotInformedException(string message, Exception inner): base(message, inner)
    {
        
    }
}
