using Application.Features.IlanListes.Commands.Create;
using Application.Features.IlanListes.Commands.Delete;
using Application.Features.IlanListes.Commands.Update;
using Application.Features.IlanListes.Queries.GetById;
using Application.Features.IlanListes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IlanListesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedIlanListeResponse>> Add([FromBody] CreateIlanListeCommand command)
    {
        CreatedIlanListeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedIlanListeResponse>> Update([FromBody] UpdateIlanListeCommand command)
    {
        UpdatedIlanListeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedIlanListeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteIlanListeCommand command = new() { Id = id };

        DeletedIlanListeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdIlanListeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdIlanListeQuery query = new() { Id = id };

        GetByIdIlanListeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListIlanListeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListIlanListeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListIlanListeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}