using FluentValidation;

using TarefaNinja.Utils.Requests;

namespace TarefaNinja.Utils.Validators;

public class NewTaskRequestValidator : AbstractValidator<NewTaskRequest>
{
    public NewTaskRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3, 100);
        RuleFor(x => x.Status).IsInEnum();
        RuleFor(x => x.ProjectId).NotEmpty();
    }
}