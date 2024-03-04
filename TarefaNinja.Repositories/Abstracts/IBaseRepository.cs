using TarefaNinja.DAL.Abstracts;

namespace TarefaNinja.Repositories.Abstracts;
public interface IBaseRepository<T> where T : BaseModel
{
    Task<bool> ExistsAsync(Guid id);
    Task DeleteAsync(Guid id);
    Task<ICollection<T>> GetAllAsync(int page = 0, int pageSize = 0);
    Task<T?> GetByIdAsync(Guid id);
    void Insert(T model);
    void Update(T model);

    Task<int> SaveChangesAsync();
}
