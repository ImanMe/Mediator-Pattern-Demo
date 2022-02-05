using WhatToDo.Application.Features.Items.Dtos;

namespace WhatToDo.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandResponse : BaseResponse
    {
        public ToDoItemDto Item { get; set; }
    }
}
