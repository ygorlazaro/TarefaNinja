using FluentValidation;

using TarefaNinja.Utils.Requests;

namespace TarefaNinja.Utils.Validators;

public class NewCompanyRequestValidator : AbstractValidator<NewCompanyRequest>
{
    public NewCompanyRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3, 100);
    }
}
