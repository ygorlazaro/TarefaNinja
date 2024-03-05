using FluentValidation;

using TarefaNinja.Utils.Requests;

namespace TarefaNinja.Utils.Validators;

public class NewLabelRequestValidator : AbstractValidator<NewLabelRequest>
{
    public NewLabelRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3, 100);
        RuleFor(x => x.Color).NotEmpty();
        RuleFor(x => x.ProjectId).NotEmpty();
    }
}