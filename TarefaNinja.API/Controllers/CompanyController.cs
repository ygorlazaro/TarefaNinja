using Microsoft.AspNetCore.Mvc;

using TarefaNinja.API.Abstracts;
using TarefaNinja.Domain;
using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.API.Controllers;

public class CompanyController : BaseController
{
    private ICompanyDomain CompanyDomain { get; }

    private IProjectDomain ProjectDomain { get; }

    public CompanyController(ICompanyDomain companyDomain, IProjectDomain projectDomain)
    {
        CompanyDomain = companyDomain;
        ProjectDomain = projectDomain;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<CompanyUserResponse>>> GetCompaniesAsync()
    {
        var companies = await CompanyDomain.GetByUserAsync(GetUserId());

        return Ok(companies);
    }

    [HttpGet("{companyId}/project")]
    public async Task<ActionResult<ICollection<ProjectResponse>>> GetProjectsAsync([FromRoute] Guid companyId)
    {
        var projects = await ProjectDomain.GetProjectsAsync(companyId);

        return Ok(projects);
    }

    [HttpPost]
    public async Task<ActionResult<CompanyUserResponse>> PostAsync([FromBody] NewCompanyRequest companyUserRequest)
    {
        var userId = GetUserId();

        var company = await CompanyDomain.CreateCompanyAsync(companyUserRequest, userId);

        if (company is null)
        {
            return BadRequest();
        }

        return Ok(company);
    }
}
