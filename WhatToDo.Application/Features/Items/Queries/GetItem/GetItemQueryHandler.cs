using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WhatToDo.Application.Features.Items.Dtos;
using WhatToDo.Domain.Contracts;
using WhatToDo.Domain.Entities;

namespace WhatToDo.Application.Features.Items.Queries.GetItem;

public class GetItemQueryHandler : IRequestHandler<GetItemQueryRequest, ToDoItemDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository<ToDoItem> _repository;

    public GetItemQueryHandler(IMapper mapper, IRepository<ToDoItem> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }


    public async Task<ToDoItemDto> Handle(GetItemQueryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id);

        return _mapper.Map<ToDoItemDto>(item);
    }
}