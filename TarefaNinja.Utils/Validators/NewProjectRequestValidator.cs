using FluentValidation;

using TarefaNinja.Utils.Requests;

namespace TarefaNinja.Utils.Validators;

public class NewProjectRequestValidator : AbstractValidator<NewProjectRequest>
{
    public NewProjectRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3, 100);
        RuleFor(x => x.Status).IsInEnum();
        RuleFor(x => x.CompanyId).NotEmpty();
    }
}