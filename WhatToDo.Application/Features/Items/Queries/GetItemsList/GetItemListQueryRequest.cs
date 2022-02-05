using System.Collections.Generic;
using MediatR;
using WhatToDo.Application.Features.Items.Dtos;

namespace WhatToDo.Application.Features.Items.Queries.GetItemsList
{
    public class GetItemListQueryRequest : IRequest<IReadOnlyCollection<ToDoItemDto>>
    {

    }
}
