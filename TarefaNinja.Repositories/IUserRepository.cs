using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;

namespace TarefaNinja.Repositories;

public interface IUserRepository : IBaseRepository<UserModel>
{
    Task<UserModel?> DoLogin(string username);

    Task<bool> ExistsAsync(string username, string email);
}
