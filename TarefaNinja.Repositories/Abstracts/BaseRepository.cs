using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

using TarefaNinja.DAL;
using TarefaNinja.DAL.Abstracts;

namespace TarefaNinja.Repositories.Abstracts;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    public BaseRepository(DefaultContext context)
    {
        Context = context;
    }

    public DefaultContext Context { get; }

    public virtual async Task<int> CountAsync()
    {
        return await Context.Set<T>().CountAsync();
    }

    public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
        return await Context.Set<T>().CountAsync(predicate);
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<ICollection<T>> GetAllAsync(int page = 0, int pageSize = 0)
    {
        var query = Context.Set<T>().AsQueryable();

        if (page == 0 || pageSize == 0)
        {
            return await query.ToListAsync();
        }

        return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            return;
        }

        Context.Set<T>().Remove(entity);
    }

    public virtual async Task<T> InsertAsync(T model)
    {
        Context.Set<T>().Add(model);

        await Context.SaveChangesAsync();

        return model;
    }

    public virtual async Task<T> UpdateAsync(T model)
    {
        Context.Set<T>().Update(model);

        await Context.SaveChangesAsync();

        return model;
    }

    public virtual async Task<bool> ExistsAsync(Guid id)
    {
        return await Context.Set<T>().AnyAsync(m => m.Id == id);
    }

    public virtual async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }
}
