namespace NetArchitecture.Core.ToDoItem;

public interface ICreateToDoItemService
{
    Task<ToDoItem> CreateToDoItemAsync(string description, CancellationToken cancellationToken = default);
}