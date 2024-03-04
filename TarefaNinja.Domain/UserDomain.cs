using Microsoft.AspNetCore.Identity;

using TarefaNinja.DAL.Models;
using TarefaNinja.Domain.Requests;
using TarefaNinja.Domain.Responses;
using TarefaNinja.Repositories;
using TarefaNinja.Services;
using TarefaNinja.Utils.Enums;
using TarefaNinja.Utils.Exceptions;

namespace TarefaNinja.Domain;
public class UserDomain : IUserDomain
{
    private IUserRepository UserRepository { get; }

    private ICompanyRepository CompanyRepository { get; }

    private IUserCompanyRepository UserCompanyRepository { get; }

    private IPasswordHasher PasswordHasher { get; }

    public UserDomain(IUserRepository userRepository, ICompanyRepository companyRepository, IUserCompanyRepository userCompanyRepository, IPasswordHasher passwordHasher)
    {
        UserRepository = userRepository;
        CompanyRepository = companyRepository;
        UserCompanyRepository = userCompanyRepository;
        PasswordHasher = passwordHasher;
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

        var hashedPassword = PasswordHasher.Hash(userRequest.Password);

        var user = new UserModel(userRequest.Name, userRequest.Username, userRequest.Email, hashedPassword);

        UserRepository.Insert(user);

        await UserCompanyRepository.AddUserToCompanyAsync(user.Id, company.Id, role);

        await UserRepository.SaveChangesAsync();

        return new NewUserResponse(user.Id, user.Name, user.Username, user.Email, company.Id, company.Name, role);
    }


    public async Task<UserLoginResponse> LoginAsync(string username, string password)
    {
        var user = await UserRepository.DoLogin(username);

        if (user is null)
        {
            throw new UserNotFoundException("O usuário informado não foi encontrado");
        }

        var (verifiedPassword, _) = PasswordHasher.Check(user.Password, password);

        if (verifiedPassword)
        {
            throw new InvalidPasswordException("A senha informada não confere");
        }

        return new UserLoginResponse(user.Id, user.Name, user.Username, user.Email);
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

        CompanyRepository.Insert(newCompany);

        await CompanyRepository.SaveChangesAsync();

        return (newCompany, true);
    }

}

