using System.Threading.Tasks;
using Moq;
using UnitTests.Config;
using WhatToDo.Application.Features.Items.Commands.CreateItem;
using WhatToDo.Domain.Contracts;
using WhatToDo.Domain.Entities;
using Xunit;

namespace UnitTests.Application.Validators;

public class CreateItemCommandValidatorTest
{
    [Fact]
    public async Task Should_Not_Allow_Null()
    {
        var toDoItemRepository = new Mock<IRepository<ToDoItem>>();

        var validator = new CreateItemCommandValidator(toDoItemRepository.Object);

        var createItem = new CreateItemCommandRequest { Description = null };

        Assert.False((await validator.ValidateAsync(createItem)).IsValid);
    }

    [Fact]
    public async Task Should_Not_Allow_Empty()
    {
        var toDoItemRepository = new Mock<IRepository<ToDoItem>>();

        var validator = new CreateItemCommandValidator(toDoItemRepository.Object);

        var createItem = new CreateItemCommandRequest { Description = string.Empty };

        Assert.False((await validator.ValidateAsync(createItem)).IsValid);
    }

    [Fact]
    public void Should_Not_Allow_More_Than_60_Characters()
    {
        var toDoItemRepository = new Mock<IRepository<ToDoItem>>();

        var validator = new CreateItemCommandValidator(toDoItemRepository.Object);

        var createItem = new CreateItemCommandRequest
            { Description = "Lorem ipsum dolor sitLorem ipsum dolor sitLorem ipsum dolor sit1" };

        Assert.False(validator.Validate(createItem).IsValid);
    }

    [Fact]
    public void Should_Allow_Valid_Description()
    {
        var toDoItemRepository = new Mock<IRepository<ToDoItem>>();

        var validator = new CreateItemCommandValidator(toDoItemRepository.Object);

        var createItem = new CreateItemCommandRequest { Description = "Walk the dog" };

        Assert.True(validator.Validate(createItem).IsValid);
    }

    [Fact]
    public void Should_Not_Allow_Duplicate()
    {
        var toDoItemRepository = InMemorySetup.GetInMemoryToDoItemRepository();

        var validator = new CreateItemCommandValidator(toDoItemRepository);

        var createItem = new CreateItemCommandRequest { Description = "First item" };

        Assert.False(validator.Validate(createItem).IsValid);
    }
}