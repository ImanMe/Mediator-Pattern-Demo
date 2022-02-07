using System.Threading.Tasks;
using Moq;
using UnitTests.Config;
using WhatToDo.Application.Features.Items.Commands.UpdateItem;
using WhatToDo.Domain.Contracts;
using WhatToDo.Domain.Entities;
using Xunit;

namespace UnitTests.Application.Validators
{
    public class UpdateItemCommandValidatorTest
    {
        [Fact]
        public async Task Should_Not_Allow_Null()
        {
            var toDoItemRepository = new Mock<IRepository<ToDoItem>>();

            var validator = new UpdateItemCommandValidator(toDoItemRepository.Object);

            var createItem = new UpdateItemCommandRequest { Description = null };

            Assert.False((await validator.ValidateAsync(createItem)).IsValid);
        }

        [Fact]
        public async Task Should_Not_Allow_Empty()
        {
            var toDoItemRepository = new Mock<IRepository<ToDoItem>>();

            var validator = new UpdateItemCommandValidator(toDoItemRepository.Object);

            var createItem = new UpdateItemCommandRequest { Description = string.Empty };

            Assert.False((await validator.ValidateAsync(createItem)).IsValid);
        }

        [Fact]
        public void Should_Not_Allow_More_Than_60_Characters()
        {
            var toDoItemRepository = new Mock<IRepository<ToDoItem>>();

            var validator = new UpdateItemCommandValidator(toDoItemRepository.Object);

            var createItem = new UpdateItemCommandRequest
            { Description = "Lorem ipsum dolor sitLorem ipsum dolor sitLorem ipsum dolor sit1" };

            Assert.False(validator.Validate(createItem).IsValid);
        }

        [Fact]
        public void Should_Allow_Valid_Description()
        {
            var toDoItemRepository = new Mock<IRepository<ToDoItem>>();

            var validator = new UpdateItemCommandValidator(toDoItemRepository.Object);

            var createItem = new UpdateItemCommandRequest { Description = "Walk the dog" };

            Assert.True(validator.Validate(createItem).IsValid);
        }

        [Fact]
        public void Should_Not_Allow_Duplicate_With_Same_IsCompleted_State()
        {
            var toDoItemRepository = InMemorySetup.GetInMemoryToDoItemRepository();

            var validator = new UpdateItemCommandValidator(toDoItemRepository);

            var createItem = new UpdateItemCommandRequest { Description = "First item", IsCompleted = false};

            Assert.False(validator.Validate(createItem).IsValid);
        }

        [Fact]
        public void Should_Allow_Duplicate_With_Different_IsCompleted_State()
        {
            var toDoItemRepository = InMemorySetup.GetInMemoryToDoItemRepository();

            var validator = new UpdateItemCommandValidator(toDoItemRepository);

            var createItem = new UpdateItemCommandRequest { Description = "First item", IsCompleted = true };

            Assert.True(validator.Validate(createItem).IsValid);
        }
    }
}
