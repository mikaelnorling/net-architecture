using FluentValidation;

namespace NetArchitecture.Core.ToDoItem;

public class ToDoItemValidator : AbstractValidator<ToDoItem>
{
    public ToDoItemValidator()
    {
        RuleFor(x => x.Description).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
    }
}