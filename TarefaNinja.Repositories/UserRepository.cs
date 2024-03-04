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

    public async Task<UserModel?> DoLogin(string username, string password)
    {
        var user = await Context.Users.FirstOrDefaultAsync(user => user.Username == username);

        if (user is null)
        {
            return null;
        }

        return user;
    }

    public async Task<bool> ExistsAsync(string username, string email)
    {
        var cleanUsername = username.Trim().ToLower();
        var cleanEmail = email.Trim().ToLower();

        return await Context.Users.AnyAsync(u => u.Username.Trim().ToLower() == cleanUsername || u.Email.Trim().ToLower() == cleanEmail);
    }
}
