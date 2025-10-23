using FluentValidation;
using NetArchitecture.Core.ToDoItem;
using Shouldly;

namespace NetArchitecture.Core.Tests.ToDoItem;

public class CreateToDoItemServiceTests
{
    [Fact]
    private async Task CreateToDoItemAsync_ItemCreatedSuccessfully()
    {
        var service = new CreateToDoItemService(new InlineValidator<Core.ToDoItem.ToDoItem>());
        
        var createdItem = await service.CreateToDoItemAsync("Test");
        
        createdItem.Description.ShouldBe("Test");
        createdItem.Completed.ShouldBeFalse();
    }
}