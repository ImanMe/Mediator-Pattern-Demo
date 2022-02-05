using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WhatToDo.Application.Features.Items.Dtos;
using WhatToDo.Domain.Contracts;
using WhatToDo.Domain.Entities;

namespace WhatToDo.Application.Features.Items.Commands.CreateItem;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommandRequest, CreateItemCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepository<ToDoItem> _repository;

    public CreateItemCommandHandler(IMapper mapper, IRepository<ToDoItem> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateItemCommandResponse> Handle(CreateItemCommandRequest request,
        CancellationToken cancellationToken)
    {
        var createItemCommandResponse = new CreateItemCommandResponse();

        var validator = new CreateItemCommandValidator(_repository);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            createItemCommandResponse.Success = false;

            createItemCommandResponse.Message = "No item was created";

            createItemCommandResponse.ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
                createItemCommandResponse.ValidationErrors.Add(error.ErrorMessage);
        }
        else
        {
            createItemCommandResponse.Success = true;

            createItemCommandResponse.Message = "An item was successfully created.";

            var item = new ToDoItem { Description = request.Description };

            var createdItem = await _repository.AddAsync(item);

            createItemCommandResponse.Item = _mapper.Map<ToDoItemDto>(createdItem);
        }

        return createItemCommandResponse;
    }
}