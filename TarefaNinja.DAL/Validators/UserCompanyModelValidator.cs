using FluentValidation;

using TarefaNinja.DAL.Models;

namespace TarefaNinja.DAL.Validators;

public class UserCompanyModelValidator : AbstractValidator<UserCompanyModel>
{
    public UserCompanyModelValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.CompanyId).NotEmpty();
    }
}