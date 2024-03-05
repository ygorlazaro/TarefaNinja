using TarefaNinja.Repositories;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.Domain;

public class CompanyDomain : ICompanyDomain
{
    private ICompanyRepository CompanyRepository { get; }

    public CompanyDomain(ICompanyRepository companyRepository)
    {
        CompanyRepository = companyRepository;
    }

    public async Task<ICollection<CompanyUserResponse>> GetByUserAsync(Guid userId)
    {
        var companies = await CompanyRepository.GetByUserAsync(userId);

        return companies.Select(company => new CompanyUserResponse(company.Id, company.Name)).ToList();
    }
}
