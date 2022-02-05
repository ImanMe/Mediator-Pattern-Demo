//using Moq;
//using WhatToDo.Api.Dtos;
//using WhatToDo.Api.Validations;
//using WhatToDo.Core.Contracts;
//using Xunit;

//namespace WhatToDo.Api.UnitTest
//{
//    public class UpdateItemDtoValidatorTest
//    {
//        [Fact]
//        public void Should_Not_Allow_Empty()
//        {
//            var toDoItemRepository = new Mock<IToDoItemRepository>();

//            var validator = new UpdateItemDtoValidator(toDoItemRepository.Object);

//            var updateItem = new UpdateItemDto() { Description = string.Empty };

//            Assert.False(validator.Validate(updateItem).IsValid);
//        }

//        [Fact]
//        public void Should_Not_Allow_Null()
//        {
//            var toDoItemRepository = new Mock<IToDoItemRepository>();

//            var validator = new UpdateItemDtoValidator(toDoItemRepository.Object);

//            var createItem = new UpdateItemDto { Description = null };

//            Assert.False(validator.Validate(createItem).IsValid);
//        }

//        [Fact]
//        public void Should_Not_Allow_More_Than_60_Characters()
//        {
//            var toDoItemRepository = new Mock<IToDoItemRepository>();

//            var validator = new UpdateItemDtoValidator(toDoItemRepository.Object);

//            var createItem = new UpdateItemDto { Description = "Lorem ipsum dolor sitLorem ipsum dolor sitLorem ipsum dolor sit1" };

//            Assert.False(validator.Validate(createItem).IsValid);
//        }

//        [Fact]
//        public void Should_Allow_Valid_Description()
//        {
//            var toDoItemRepository = new Mock<IToDoItemRepository>();

//            var validator = new UpdateItemDtoValidator(toDoItemRepository.Object);

//            var createItem = new UpdateItemDto { Description = "Walk the dog" };

//            Assert.True(validator.Validate(createItem).IsValid);
//        }
//    }
//}
