//using Moq;
//using WhatToDo.Api.Dtos;
//using WhatToDo.Api.Validations;
//using WhatToDo.Core.Contracts;
//using Xunit;

//namespace WhatToDo.Api.UnitTest;

//public class CreateItemDtoValidatorTest
//{
//    [Fact]
//    public void Should_Not_Allow_Empty()
//    {
//        var toDoItemRepository = new Mock<IToDoItemRepository>();

//        var validator = new CreateItemDtoValidator(toDoItemRepository.Object);

//        toDoItemRepository.Setup(p =>
//                p.IsDuplicateAsync(It.IsAny<string>(), It.IsAny<bool>()))
//            .ReturnsAsync(false).Verifiable();

//        var createItem = new CreateItemDto { Description = string.Empty };

//        Assert.False(validator.Validate(createItem).IsValid);
//    }

//    [Fact]
//    public void Should_Not_Allow_Null()
//    {
//        var toDoItemRepository = new Mock<IToDoItemRepository>();

//        var validator = new CreateItemDtoValidator(toDoItemRepository.Object);

//        toDoItemRepository.Setup(p =>
//                p.IsDuplicateAsync(It.IsAny<string>(), It.IsAny<bool>()))
//            .ReturnsAsync(false).Verifiable();

//        var createItem = new CreateItemDto { Description = null };

//        Assert.False(validator.Validate(createItem).IsValid);
//    }

//    [Fact]
//    public void Should_Not_Allow_More_Than_60_Characters()
//    {
//        var toDoItemRepository = new Mock<IToDoItemRepository>();

//        var validator = new CreateItemDtoValidator(toDoItemRepository.Object);

//        toDoItemRepository.Setup(p =>
//                p.IsDuplicateAsync(It.IsAny<string>(), It.IsAny<bool>()))
//            .ReturnsAsync(false).Verifiable();

//        var createItem = new CreateItemDto { Description = "Lorem ipsum dolor sitLorem ipsum dolor sitLorem ipsum dolor sit1" };

//        Assert.False(validator.Validate(createItem).IsValid);
//    }

//    [Fact]
//    public void Should_Allow_Valid_Description()
//    {
//        var toDoItemRepository = new Mock<IToDoItemRepository>();

//        var validator = new CreateItemDtoValidator(toDoItemRepository.Object);

//        toDoItemRepository.Setup(p =>
//                p.IsDuplicateAsync(It.IsAny<string>(), It.IsAny<bool>()))
//            .ReturnsAsync(false).Verifiable();

//        var createItem = new CreateItemDto { Description = "Walk the dog" };

//        Assert.True(validator.Validate(createItem).IsValid);
//    }

//    [Fact]
//    public void Should_Not_Allow_Duplicate()
//    {
//        var toDoItemRepository = new Mock<IToDoItemRepository>();

//        var validator = new CreateItemDtoValidator(toDoItemRepository.Object);

//        toDoItemRepository.Setup(p =>
//                p.IsDuplicateAsync(It.IsAny<string>(), It.IsAny<bool>()))
//            .ReturnsAsync(true).Verifiable();

//        var createItem = new CreateItemDto { Description = "Walk the dog" };

//        Assert.False(validator.Validate(createItem).IsValid);
//    }
//}