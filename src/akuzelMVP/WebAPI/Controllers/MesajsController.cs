using Application.Features.Mesajs.Commands.Create;
using Application.Features.Mesajs.Commands.Delete;
using Application.Features.Mesajs.Commands.Update;
using Application.Features.Mesajs.Queries.GetById;
using Application.Features.Mesajs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MesajsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedMesajResponse>> Add([FromBody] CreateMesajCommand command)
    {
        CreatedMesajResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedMesajResponse>> Update([FromBody] UpdateMesajCommand command)
    {
        UpdatedMesajResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedMesajResponse>> Delete([FromRoute] Guid id)
    {
        DeleteMesajCommand command = new() { Id = id };

        DeletedMesajResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdMesajResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdMesajQuery query = new() { Id = id };

        GetByIdMesajResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListMesajQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMesajQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListMesajListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}