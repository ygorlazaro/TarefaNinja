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

    public async Task<UserModel?> DoLogin(string username)
    {
        var query = from user in Context.Users
                    where user.Username == username
                    select new UserModel(user.Id, user.Name, user.Username, user.Email, user.Password);

        var userFound = await query.FirstOrDefaultAsync();

        if (userFound is null)
        {
            return null;
        }

        return userFound;
    }

    public async Task<bool> ExistsAsync(string username, string email)
    {
        var cleanUsername = username.Trim().ToLower();
        var cleanEmail = email.Trim().ToLower();

        return await Context.Users.AnyAsync(u => u.Username.Trim().ToLower() == cleanUsername || u.Email.Trim().ToLower() == cleanEmail);
    }
}
