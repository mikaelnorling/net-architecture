using FluentValidation;

namespace NetArchitecture.Core.ToDoItem;

public class CreateToDoItemService(IValidator<ToDoItem> toDoItemValidator) : ICreateToDoItemService
{
    private readonly IValidator<ToDoItem> _toDoItemValidator = toDoItemValidator;

    public async Task<ToDoItem> CreateToDoItemAsync(string description, CancellationToken cancellationToken = default)
    {
        var toDoItem = new ToDoItem
        {
            Description = description,
            Completed = false
        };
        
        await _toDoItemValidator.ValidateAndThrowAsync(toDoItem, cancellationToken: cancellationToken);

        return toDoItem;
    }
}