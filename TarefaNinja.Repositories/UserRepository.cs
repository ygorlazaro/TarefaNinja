using Microsoft.EntityFrameworkCore;

using TarefaNinja.DAL;
using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;

namespace TarefaNinja.Repositories;

public class UserRepository : BaseRepository<UserModel>, IUserRepository
{
    public UserRepository(DefaultContext context) : base(context)
    {
    }

    public async Task<UserModel?> DoLogin(string login)
    {
        var query = from user in Context.Users
                    where user.Login == login
                    select new UserModel(user.Id, user.Name, user.Login, user.Email, user.Password);

        var userFound = await query.FirstOrDefaultAsync();

        if (userFound is null)
        {
            return null;
        }

        return userFound;
    }

    public async Task<bool> ExistsAsync(string login, string email)
    {
        var cleanLogin = login.Trim().ToLower();
        var cleanEmail = email.Trim().ToLower();

        return await Context.Users.AnyAsync(u => u.Login.Trim().ToLower() == cleanLogin || u.Email.Trim().ToLower() == cleanEmail);
    }
}
