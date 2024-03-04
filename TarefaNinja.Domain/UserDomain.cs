using TarefaNinja.DAL.Models;
using TarefaNinja.Domain.Requests;
using TarefaNinja.Domain.Responses;
using TarefaNinja.Repositories;
using TarefaNinja.Utils.Enums;
using TarefaNinja.Utils.Exceptions;

namespace TarefaNinja.Domain;
public class UserDomain : IUserDomain
{
    private IUserRepository UserRepository { get; }

    private ICompanyRepository CompanyRepository { get; }

    private IUserCompanyRepository UserCompanyRepository { get; }

    public UserDomain(IUserRepository userRepository, ICompanyRepository companyRepository, IUserCompanyRepository userCompanyRepository)
    {
        UserRepository = userRepository;
        CompanyRepository = companyRepository;
        UserCompanyRepository = userCompanyRepository;
    }

    public async Task<NewUserResponse> CreateNewUserAsync(NewUserRequest userRequest)
    {
        var exists = await UserRepository.ExistsAsync(userRequest.Username, userRequest.Email);

        if (exists)
        {
            throw new ExistingUserException("Login ou e-mail já existe");
        }

        var (company, isNewCompany) = await GetOrCreateCompanyAsync(userRequest.CompanyId, userRequest.CompanyName);
        var role = isNewCompany ? UserCompanyRole.Admin : userRequest.Role;

        var user = new UserModel(userRequest.Name, userRequest.Username, userRequest.Email, userRequest.Password);

        var insertedUser = await UserRepository.InsertAsync(user);

        await UserCompanyRepository.AddUserToCompanyAsync(insertedUser.Id, company.Id, role);

        return new NewUserResponse(insertedUser.Id, insertedUser.Name, insertedUser.Username, insertedUser.Email, company.Id, company.Name, role);
    }

    private async Task<(CompanyModel company, bool Created)> GetOrCreateCompanyAsync(Guid? companyId, string? companyName)
    {
        if (companyId is null && string.IsNullOrWhiteSpace(companyName))
        {
            throw new MissingCompanyInfoException("A empresa não foi informada para o cadastro ou associação");
        }

        if (companyId is not null)
        {
            var company = await CompanyRepository.GetByIdAsync(companyId.Value);

            if (company is null)
            {
                throw new CompanyNotFoundException("A empresa informada não foi encontrada");
            }

            return (company, false);
        }

        if (string.IsNullOrWhiteSpace(companyName))
        {
            throw new CompanyInfoNotInformedException("O nome da empresa não foi informado");
        }

        var newCompany = new CompanyModel(companyName);

        return (await CompanyRepository.InsertAsync(newCompany), true);
    }
}

