using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories;
using TarefaNinja.Utils.Enums;
using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.Domain;

public class CompanyDomain : ICompanyDomain
{
    private ICompanyRepository CompanyRepository { get; }
    private IUserCompanyRepository UserCompanyRepository { get; }

    public CompanyDomain(ICompanyRepository companyRepository)
    {
        CompanyRepository = companyRepository;
    }

    public async Task<ICollection<CompanyUserResponse>> GetByUserAsync(Guid userId)
    {
        var companies = await CompanyRepository.GetByUserAsync(userId);

        return companies.Select(company => new CompanyUserResponse(company.Id, company.Name)).ToList();
    }

    public async Task<CompanyUserResponse?> CreateCompanyAsync(NewCompanyRequest companyUserRequest, Guid userId)
    {
        var company = await CompanyRepository.InsertAsync(new CompanyModel(companyUserRequest.Name));

        if (company is null)
        {
            return null;
        }

        await CompanyRepository.AddUserToCompanyAsync(userId, company.Id, UserCompanyRole.Admin);

        return new CompanyUserResponse(company.Id, company.Name);
    }
}
