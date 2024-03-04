namespace TarefaNinja.DAL.Abstracts;

public abstract record BaseModel(Guid Id, DateTimeOffset Created, DateTimeOffset? Updated, DateTimeOffset? Deleted)
{
    protected BaseModel() : this(Id: Guid.NewGuid(), Created: DateTimeOffset.Now, Updated: null, Deleted: null)
    {

    }
}
