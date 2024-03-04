using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;

namespace TarefaNinja.Repositories;

public interface IUserRepository : IBaseRepository<UserModel>
{
    Task<UserModel?> DoLogin(string login);

    Task<bool> ExistsAsync(string login, string email);
}
