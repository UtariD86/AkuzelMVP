using Application.Features.Listes.Commands.Create;
using Application.Features.Listes.Commands.Delete;
using Application.Features.Listes.Commands.Update;
using Application.Features.Listes.Queries.GetById;
using Application.Features.Listes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ListesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedListeResponse>> Add([FromBody] CreateListeCommand command)
    {
        CreatedListeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedListeResponse>> Update([FromBody] UpdateListeCommand command)
    {
        UpdatedListeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedListeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteListeCommand command = new() { Id = id };

        DeletedListeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdListeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdListeQuery query = new() { Id = id };

        GetByIdListeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListListeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListListeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListListeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}