using Application.Features.MesajEks.Commands.Create;
using Application.Features.MesajEks.Commands.Delete;
using Application.Features.MesajEks.Commands.Update;
using Application.Features.MesajEks.Queries.GetById;
using Application.Features.MesajEks.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MesajEksController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedMesajEkResponse>> Add([FromBody] CreateMesajEkCommand command)
    {
        CreatedMesajEkResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedMesajEkResponse>> Update([FromBody] UpdateMesajEkCommand command)
    {
        UpdatedMesajEkResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedMesajEkResponse>> Delete([FromRoute] Guid id)
    {
        DeleteMesajEkCommand command = new() { Id = id };

        DeletedMesajEkResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdMesajEkResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdMesajEkQuery query = new() { Id = id };

        GetByIdMesajEkResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListMesajEkQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMesajEkQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListMesajEkListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}