using MediatR;

namespace WhatToDo.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemCommandRequest : IRequest<UpdateItemCommandResponse>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
