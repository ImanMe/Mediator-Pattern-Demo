using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WhatToDo.Core.Contracts;
using WhatToDo.Core.Entities;

namespace WhatToDo.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommandRequest, UpdateItemCommandResponse>
    {
        private readonly IRepository<ToDoItem> _repository;

        public UpdateItemCommandHandler(IRepository<ToDoItem> repository)
        {
            _repository = repository;
        }
        public async Task<UpdateItemCommandResponse> Handle(UpdateItemCommandRequest request, CancellationToken cancellationToken)
        {
            var updateItemCommandResponse = new UpdateItemCommandResponse();

            var validator = new UpdateItemCommandValidator(_repository);

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                updateItemCommandResponse.Success = false;

                updateItemCommandResponse.Message = "No item was updated";

                updateItemCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                    updateItemCommandResponse.ValidationErrors.Add(error.ErrorMessage);

                return updateItemCommandResponse;
            }

            var itemToBeUpdated = await _repository.GetByIdAsync(request.Id);

            if (itemToBeUpdated == null)
            {
                updateItemCommandResponse.Success = false;

                updateItemCommandResponse.Message = "No item was updated";

                updateItemCommandResponse.ValidationErrors.Add($"No item with Id: {request.Id} was found.");

                return updateItemCommandResponse;
            }

            itemToBeUpdated.Description = request.Description;
            itemToBeUpdated.IsCompleted = request.IsCompleted;

            await _repository.UpdateAsync(itemToBeUpdated);

            updateItemCommandResponse.Success = true;
            updateItemCommandResponse.Message = "Item was successfully updated.";

            return updateItemCommandResponse;
        }
    }
}
