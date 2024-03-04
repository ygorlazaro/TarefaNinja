using FluentValidation;
using TarefaNinja.Domain.Requests;

namespace TarefaNinja.Domain.Validators;

public class NewTokenRequestValidator : AbstractValidator<NewTokenRequest>
{
    public NewTokenRequestValidator()
    {
        RuleFor(x => x.Username).NotEmpty().Length(3, 100);
        RuleFor(x => x.Password).NotEmpty().Length(3, 100);
    }
}
