using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

using TarefaNinja.DAL;
using TarefaNinja.DAL.Abstracts;

namespace TarefaNinja.Repositories.Abstracts;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    protected BaseRepository(DefaultContext context)
    {
        Context = context;
    }

    protected DefaultContext Context { get; }

    protected async Task<int> CountAsync()
    {
        return await Context.Set<T>().CountAsync();
    }

    protected async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
        return await Context.Set<T>().CountAsync(predicate);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<T>> GetAllAsync(int page = 0, int pageSize = 0)
    {
        var query = Context.Set<T>().AsQueryable();

        if (page == 0 || pageSize == 0)
        {
            return await query.ToListAsync();
        }

        return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            return true;
        }

        Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync();

        return false;
    }

    public async Task<T> InsertAsync(T model)
    {
        Context.Set<T>().Add(model);
        await Context.SaveChangesAsync();

        return model;
    }

    public async Task<bool> UpdateAsync(T model)
    {
        try
        {
            Context.Set<T>().Update(model);

            await Context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await Context.Set<T>().AnyAsync(m => m.Id == id);
    }
}
