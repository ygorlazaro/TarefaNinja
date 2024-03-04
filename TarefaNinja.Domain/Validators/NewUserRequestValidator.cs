using FluentValidation;

using TarefaNinja.Domain.Requests;

namespace TarefaNinja.Domain.Validators;

public class NewUserRequestValidator : AbstractValidator<NewUserRequest>
{
    public NewUserRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3, 100);
        RuleFor(x => x.Login).NotEmpty().Length(3, 100);
        RuleFor(x => x.Email).NotEmpty().Length(3, 100).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().Length(3, 100);
        RuleFor(x => x.Role).IsInEnum();
        RuleFor(x => x.CompanyId).NotEmpty().When(x => x.CompanyId is not null);
        RuleFor(x => x.CompanyName).NotEmpty().Length(3, 100).When(x => x.CompanyName is null);
    }
}
