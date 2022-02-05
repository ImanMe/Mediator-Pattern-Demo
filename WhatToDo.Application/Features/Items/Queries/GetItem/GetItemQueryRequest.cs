using MediatR;
using WhatToDo.Application.Features.Items.Dtos;

namespace WhatToDo.Application.Features.Items.Queries.GetItem
{
    public class GetItemQueryRequest : IRequest<ToDoItemDto>
    {
        public int Id { get; set; }
    }
}
