using AutoMapper;
using WhatToDo.Application.Features.Items.Dtos;
using WhatToDo.Domain.Entities;

namespace WhatToDo.Application.MappingProfiles;

public class ToDoItemProfile : Profile
{
    public ToDoItemProfile()
    {
        CreateMap<ToDoItem, ToDoItemDto>();

        CreateMap<ToDoItem, ToDoItemDto>()
            .ForMember(x => x.CreatedDate, o =>
                o.MapFrom(src => src.CreatedDate.ToShortDateString()));

        CreateMap<ToDoItem, ToDoItemDto>()
            .ForMember(x => x.CreatedDate, o =>
                o.MapFrom(src => src.CreatedDate.ToShortDateString()));
    }
}