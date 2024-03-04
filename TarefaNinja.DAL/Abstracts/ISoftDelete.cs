namespace TarefaNinja.DAL.Abstracts;

internal interface ISoftDelete
{
    DateTime? Deleted { get; }
}
