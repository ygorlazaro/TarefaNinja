using Microsoft.EntityFrameworkCore;

using TarefaNinja.DAL;
using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;
using TarefaNinja.Utils.Enums;

namespace TarefaNinja.Repositories;

public class CompanyRepository : BaseRepository<CompanyModel>, ICompanyRepository
{
    public CompanyRepository(DefaultContext context) : base(context)
    {
    }

    public async Task<bool> AddUserToCompanyAsync(Guid userId, Guid companyId, UserCompanyRole role)
    {
        var exists = await Context.UsersCompanies.AnyAsync(uc => uc.UserId == userId && uc.CompanyId == companyId);

        if (exists)
        {
            return false;
        }

        Context.UsersCompanies.Add(new UserCompanyModel(userId, companyId, role));

        return await Context.SaveChangesAsync() > 0;
    }
}
