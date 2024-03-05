using FluentValidation;

using TarefaNinja.Utils.Requests;

namespace TarefaNinja.Domain.Validators;

public class NewTokenRequestValidator : AbstractValidator<NewTokenRequest>
{
    public NewTokenRequestValidator()
    {
        RuleFor(x => x.Login).NotEmpty().Length(3, 100);
        RuleFor(x => x.Password).NotEmpty().Length(3, 100);
    }
}
