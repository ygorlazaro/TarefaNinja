using FluentValidation;

using TarefaNinja.DAL.Models;

namespace TarefaNinja.DAL.Validators;
public class UserModelValidator : AbstractValidator<UserModel>
{
    public UserModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3, 100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Username).NotEmpty().Length(3, 100);
        RuleFor(x => x.Password).NotEmpty().Length(3, 100);
    }
}
