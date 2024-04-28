using Application.Features.Ilans.Commands.Create;
using Application.Features.Ilans.Commands.Delete;
using Application.Features.Ilans.Commands.Update;
using Application.Features.Ilans.Queries.GetById;
using Application.Features.Ilans.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IlansController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedIlanResponse>> Add([FromBody] CreateIlanCommand command)
    {
        CreatedIlanResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedIlanResponse>> Update([FromBody] UpdateIlanCommand command)
    {
        UpdatedIlanResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedIlanResponse>> Delete([FromRoute] Guid id)
    {
        DeleteIlanCommand command = new() { Id = id };

        DeletedIlanResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdIlanResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdIlanQuery query = new() { Id = id };

        GetByIdIlanResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListIlanQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListIlanQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListIlanListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}