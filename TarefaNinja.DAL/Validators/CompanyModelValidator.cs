using FluentValidation;

using TarefaNinja.DAL.Models;

namespace TarefaNinja.DAL.Validators;

public class CompanyModelValidator : AbstractValidator<CompanyModel>
{
    public CompanyModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3, 100);
    }
}
