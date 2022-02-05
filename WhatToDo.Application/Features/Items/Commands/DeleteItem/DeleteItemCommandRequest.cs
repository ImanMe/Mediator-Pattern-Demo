using MediatR;

namespace WhatToDo.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemCommandRequest : IRequest<DeleteItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
