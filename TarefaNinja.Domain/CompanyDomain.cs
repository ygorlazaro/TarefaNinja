using TarefaNinja.Domain.Responses;
using TarefaNinja.Repositories;

namespace TarefaNinja.Domain;

public class CompanyDomain : ICompanyDomain
{
    private ICompanyRepository CompanyRepository { get; }

    public CompanyDomain(ICompanyRepository companyRepository)
    {
        CompanyRepository = companyRepository;
    }

    public async Task<ICollection<CompanyUserResponse>> GetCompaniesAsync(Guid userId)
    {
        var companies = await CompanyRepository.GetByUserAsync(userId);

        return companies.Select(company => new CompanyUserResponse(company.Id, company.Name)).ToList();
    }
}
