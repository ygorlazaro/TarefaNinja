using TarefaNinja.DAL;
using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;
using TarefaNinja.Utils.Enums;
using TarefaNinja.Utils.Exceptions;

namespace TarefaNinja.Repositories;

public class UserCompanyRepository: BaseRepository<UserCompanyModel>, IUserCompanyRepository
{
    public IUserRepository UserRepository { get; }
    public ICompanyRepository CompanyRepository { get; }

    public UserCompanyRepository(DefaultContext context, IUserRepository userRepository, ICompanyRepository companyRepository) : base(context)
    {
        UserRepository = userRepository;
        CompanyRepository  = companyRepository;
    }

    public async Task<bool> AddUserToCompanyAsync(Guid userId, Guid companyId, UserCompanyRole role)
    {
        var userExists = await UserRepository.ExistsAsync(userId);
        var companyExists = await CompanyRepository.ExistsAsync(companyId);

        if (!userExists)
        {
            throw new UserNotFoundException("O usuário informado não foi encontrado");
        }

        if (!companyExists)
        {
            throw new CompanyNotFoundException("A empresa informada não foi encontrada");
        }

        var userCompany = new UserCompanyModel(userId, companyId, role);

        Insert(userCompany);

        await SaveChangesAsync();

        return true;
    }
}
