namespace TarefaNinja.Utils.Exceptions;

public class MissingCompanyInfoException: Exception
{
    public MissingCompanyInfoException()
    {
        
    }

    public MissingCompanyInfoException(string message)
        : base(message)
    {
        
    }

    public MissingCompanyInfoException(string message, Exception inner)
        : base(message, inner)
    {
        
    }
}
