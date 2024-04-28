using Application.Features.Medyas.Commands.Create;
using Application.Features.Medyas.Commands.Delete;
using Application.Features.Medyas.Commands.Update;
using Application.Features.Medyas.Queries.GetById;
using Application.Features.Medyas.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedyasController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedMedyaResponse>> Add([FromBody] CreateMedyaCommand command)
    {
        CreatedMedyaResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedMedyaResponse>> Update([FromBody] UpdateMedyaCommand command)
    {
        UpdatedMedyaResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedMedyaResponse>> Delete([FromRoute] Guid id)
    {
        DeleteMedyaCommand command = new() { Id = id };

        DeletedMedyaResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdMedyaResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdMedyaQuery query = new() { Id = id };

        GetByIdMedyaResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListMedyaQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMedyaQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListMedyaListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}