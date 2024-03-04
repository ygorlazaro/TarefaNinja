namespace TarefaNinja.DAL.Abstracts;

public abstract record BaseModel(Guid Id, DateTime Created, DateTime? Updated, DateTime? Deleted) : ISoftDelete
{
    protected BaseModel() : this(Id: Guid.NewGuid(), Created: DateTime.Now, Updated: null, Deleted: null)
    {

    }
}
