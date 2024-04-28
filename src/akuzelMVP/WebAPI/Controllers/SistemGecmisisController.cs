using Application.Features.SistemGecmisis.Commands.Create;
using Application.Features.SistemGecmisis.Commands.Delete;
using Application.Features.SistemGecmisis.Commands.Update;
using Application.Features.SistemGecmisis.Queries.GetById;
using Application.Features.SistemGecmisis.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SistemGecmisisController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSistemGecmisiResponse>> Add([FromBody] CreateSistemGecmisiCommand command)
    {
        CreatedSistemGecmisiResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSistemGecmisiResponse>> Update([FromBody] UpdateSistemGecmisiCommand command)
    {
        UpdatedSistemGecmisiResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSistemGecmisiResponse>> Delete([FromRoute] Guid id)
    {
        DeleteSistemGecmisiCommand command = new() { Id = id };

        DeletedSistemGecmisiResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSistemGecmisiResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdSistemGecmisiQuery query = new() { Id = id };

        GetByIdSistemGecmisiResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSistemGecmisiQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSistemGecmisiQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSistemGecmisiListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}