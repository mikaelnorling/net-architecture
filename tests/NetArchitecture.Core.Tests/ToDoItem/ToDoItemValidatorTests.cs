using FluentValidation.TestHelper;
using NetArchitecture.Core.ToDoItem;

namespace NetArchitecture.Core.Tests.ToDoItem;

public class ToDoItemValidatorTests
{
    private readonly ToDoItemValidator _validator = new();

    [Fact]
    public void Should_Throw_ValidationException_When_Description_Is_Empty()
    {
        var toDoItem = new Core.ToDoItem.ToDoItem
        {
            Description = "",
            Completed = false
        };
        
        var result = _validator.TestValidate(toDoItem);
        
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }
    
    [Fact]
    public void Should_Throw_ValidationException_When_Description_Is_TooShort()
    {
        var toDoItem = new Core.ToDoItem.ToDoItem
        {
            Description = "ab",
            Completed = false
        };
        
        var result = _validator.TestValidate(toDoItem);
        
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }
    
    [Fact]
    public void Should_Throw_ValidationException_When_Description_Is_TooLong()
    {
        var toDoItem = new Core.ToDoItem.ToDoItem
        {
            Description = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                          "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                          "a",
            Completed = false
        };
        
        var result = _validator.TestValidate(toDoItem);
        
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }
    
    [Fact]
    public void Should_Not_Throw_ValidationException_When_Description_Is_OkLong()
    {
        var toDoItem = new Core.ToDoItem.ToDoItem
        {
            Description = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                          "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            Completed = false
        };
        
        var result = _validator.TestValidate(toDoItem);
        
        result.ShouldNotHaveValidationErrorFor(x => x.Description);
    }
    
    [Fact]
    public void Should_Not_Throw_ValidationException_When_Description_Is_MinimumLength()
    {
        var toDoItem = new Core.ToDoItem.ToDoItem
        {
            Description = "abc",
            Completed = false
        };
        
        var result = _validator.TestValidate(toDoItem);
        
        result.ShouldNotHaveValidationErrorFor(x => x.Description);
    }
}