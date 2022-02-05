using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WhatToDo.Domain.Contracts;
using WhatToDo.Domain.Entities;

namespace WhatToDo.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommandRequest, DeleteItemCommandResponse>
    {
        private readonly IRepository<ToDoItem> _repository;

        public DeleteItemCommandHandler(IRepository<ToDoItem> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteItemCommandResponse> Handle(DeleteItemCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteItemCommandResponse = new DeleteItemCommandResponse();

            var itemToBeDeleted = await _repository.GetByIdAsync(request.Id);

            if (itemToBeDeleted == null)
            {
                deleteItemCommandResponse.Success = false;
                deleteItemCommandResponse.Message = "No item was deleted";
                deleteItemCommandResponse.ValidationErrors.Add($"No item with id: {request.Id} exists");

                return deleteItemCommandResponse;
            }

            await _repository.DeleteAsync(itemToBeDeleted);

            deleteItemCommandResponse.Success = true;
            deleteItemCommandResponse.Message = "Item was successfully deleted";

            return deleteItemCommandResponse;
        }
    }
}
