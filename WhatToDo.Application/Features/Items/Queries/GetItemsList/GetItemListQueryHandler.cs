using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WhatToDo.Application.Features.Items.Dtos;
using WhatToDo.Domain.Contracts;
using WhatToDo.Domain.Entities;

namespace WhatToDo.Application.Features.Items.Queries.GetItemsList;

public class GetItemListQueryHandler : IRequestHandler<GetItemListQueryRequest, IReadOnlyCollection<ToDoItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<ToDoItem> _repository;

    public GetItemListQueryHandler(IMapper mapper, IRepository<ToDoItem> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<ToDoItemDto>> Handle(GetItemListQueryRequest request,
        CancellationToken cancellationToken)
    {
        var items = await _repository.GetListAsync();

        return _mapper.Map<IReadOnlyCollection<ToDoItemDto>>(items);
    }
}