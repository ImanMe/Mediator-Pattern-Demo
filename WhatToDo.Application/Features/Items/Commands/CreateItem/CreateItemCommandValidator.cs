using System.Threading.Tasks;
using FluentValidation;
using WhatToDo.Domain.Contracts;
using WhatToDo.Domain.Entities;

namespace WhatToDo.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommandRequest>
    {
        private readonly IRepository<ToDoItem> _repository;

        public CreateItemCommandValidator(IRepository<ToDoItem> repository)
        {
            _repository = repository;

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .Length(1, 60).WithMessage("Description should be between 2 and 200 characters")
                .MustAsync((o, cancellation) => IsNotDuplicate(o)).WithMessage("This item already exists.");
        }

        private async Task<bool> IsNotDuplicate(string description)
        {
            var toDoItemSpecification = new ToDoItemSpecification(description);

            var result = await _repository.GetWithSpecAsync(toDoItemSpecification);

            return result == null;
        }
    }
}
