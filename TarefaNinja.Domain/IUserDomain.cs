using TarefaNinja.Domain.Requests;
using TarefaNinja.Domain.Responses;

namespace TarefaNinja.Domain;

public interface IUserDomain
{
    Task<NewUserResponse> CreateNewUserAsync(NewUserRequest userRequest);
}
