using MediatR;
using Microsoft.AspNetCore.Mvc;
using WhatToDo.Application.Features.Items.Commands.CreateItem;
using WhatToDo.Application.Features.Items.Commands.DeleteItem;
using WhatToDo.Application.Features.Items.Commands.UpdateItem;
using WhatToDo.Application.Features.Items.Queries.GetItem;
using WhatToDo.Application.Features.Items.Queries.GetItemsList;

namespace WhatToDo.Api.Controllers;

public class ItemsController : BaseApiController
{
    private readonly IMediator _mediator;

    public ItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Get()
    {
        var getItemListQueryRequest = new GetItemListQueryRequest();

        var items = await _mediator.Send(getItemListQueryRequest);

        return Ok(items);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Get(int id)
    {
        var getItemQueryRequest = new GetItemQueryRequest { Id = id };

        var items = await _mediator.Send(getItemQueryRequest);

        return Ok(items);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Post([FromBody] CreateItemCommandRequest createItemCommandRequest)
    {
        var response = await _mediator.Send(createItemCommandRequest);

        if (response.Success) return CreatedAtAction("Get", new { id = response.Item.Id }, response);

        return BadRequest(response);
    }

    [HttpPost("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update([FromBody] UpdateItemCommandRequest updateItemCommandRequest)
    {
        var response = await _mediator.Send(updateItemCommandRequest);

        if (response.Success) return NoContent();

        return BadRequest(response);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteItemCommandRequest = new DeleteItemCommandRequest { Id = id };

        var response = await _mediator.Send(deleteItemCommandRequest);

        if (response.Success) return NoContent();

        return BadRequest(response);
    }
}