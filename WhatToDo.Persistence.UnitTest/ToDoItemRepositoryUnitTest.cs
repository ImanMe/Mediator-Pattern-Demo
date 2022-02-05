//using System;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using WhatToDo.Domain.Contracts;
//using WhatToDo.Persistence.UnitTest.Config;
//using Xunit;

//namespace WhatToDo.Persistence.UnitTest
//{
//    public class ToDoItemRepositoryUnitTest
//    {
//        private readonly IToDoItemRepository _repository;
//        public ToDoItemRepositoryUnitTest()
//        {
//            _repository = GetInMemoryToDoItemRepository();
//        }

//        [Fact]
//        public async Task Should_Get_All_Items()
//        {
//            var items = await _repository.GetAllAsync();

//            Assert.Equal(5, items.Count);

//        }

//        [Fact]
//        public async Task Should_Get_By_Id()
//        {
//            var item = await _repository.GetByIdAsync(2);

//            Assert.Equal(2, item.Id);
//            Assert.Equal("Second item", item.Description);
//            Assert.False(item.IsCompleted);

//        }

//        [Fact]
//        public async Task Should_Return_True_If_Duplicate()
//        {
//            var result = await _repository.IsDuplicateAsync("Third item", false);

//            Assert.True(result);

//        }

//        [Fact]
//        public async Task Should_Return_False_If_Not_Duplicate_Description()
//        {
//            var result = await _repository.IsDuplicateAsync("Third item changed", false);

//            Assert.False(result);

//        }

//        [Fact]
//        public async Task Should_Return_False_If_Not_Duplicate_IsCompleted()
//        {
//            var result = await _repository.IsDuplicateAsync("Third item", true);

//            Assert.False(result);

//        }

//        private static IToDoItemRepository GetInMemoryToDoItemRepository()
//        {
//            var builder = new DbContextOptionsBuilder<WhatToDoContext>();

//            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

//            var options = builder.Options;

//            var whatToDoContext = new WhatToDoContext(options);

//            whatToDoContext.Database.EnsureDeleted();

//            whatToDoContext.Database.EnsureCreated();

//            var toDoItems = ToDoItemSeed.SeedData();

//            whatToDoContext.ToDoItems.AddRange(toDoItems);

//            whatToDoContext.SaveChanges();

//            return new ToDoItemRepository(whatToDoContext);
//        }
//    }
//}