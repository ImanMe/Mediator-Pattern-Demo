using MediatR;

namespace WhatToDo.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandRequest : IRequest<CreateItemCommandResponse>
    {
        public string Description { get; set; }
    }
}
