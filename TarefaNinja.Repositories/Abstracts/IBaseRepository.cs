using TarefaNinja.DAL.Abstracts;

namespace TarefaNinja.Repositories.Abstracts;
public interface IBaseRepository<T> where T : BaseModel
{
    Task<bool> ExistsAsync(Guid id);
    Task<bool> DeleteAsync(Guid id);
    Task<ICollection<T>> GetAllAsync(int page = 0, int pageSize = 0);
    Task<T?> GetByIdAsync(Guid id);
    Task<T> InsertAsync(T model);
    Task<bool> UpdateAsync(T model);
}
