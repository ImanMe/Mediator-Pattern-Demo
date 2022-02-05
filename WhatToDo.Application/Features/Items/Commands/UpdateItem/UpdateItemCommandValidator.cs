using System.Threading.Tasks;
using FluentValidation;
using WhatToDo.Domain.Contracts;
using WhatToDo.Domain.Entities;

namespace WhatToDo.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommandRequest>
    {
        private readonly IRepository<ToDoItem> _repository;

        public UpdateItemCommandValidator(IRepository<ToDoItem> repository)
        {
            _repository = repository;
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .Length(1, 60).WithMessage("Description should be between 2 and 200 characters")
                .MustAsync((o, r, cancellation) => IsNotDuplicate(o.Description, o.IsCompleted)).WithMessage("This item already exists.");
        }

        private async Task<bool> IsNotDuplicate(string description, bool isCompleted)
        {
            var toDoItemSpecification = new ToDoItemSpecification(description, isCompleted);

            var result = await _repository.GetWithSpecAsync(toDoItemSpecification);

            return result == null;
        }
    }
}
