using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.Domain;

public interface IUserDomain
{
    Task<NewUserResponse> CreateNewUserAsync(NewUserRequest userRequest);
    Task<UserLoginResponse> LoginAsync(string login, string password);
}
