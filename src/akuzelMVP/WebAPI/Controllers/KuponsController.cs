using Application.Features.Kupons.Commands.Create;
using Application.Features.Kupons.Commands.Delete;
using Application.Features.Kupons.Commands.Update;
using Application.Features.Kupons.Queries.GetById;
using Application.Features.Kupons.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KuponsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedKuponResponse>> Add([FromBody] CreateKuponCommand command)
    {
        CreatedKuponResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedKuponResponse>> Update([FromBody] UpdateKuponCommand command)
    {
        UpdatedKuponResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedKuponResponse>> Delete([FromRoute] Guid id)
    {
        DeleteKuponCommand command = new() { Id = id };

        DeletedKuponResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdKuponResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdKuponQuery query = new() { Id = id };

        GetByIdKuponResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListKuponQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListKuponQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListKuponListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}