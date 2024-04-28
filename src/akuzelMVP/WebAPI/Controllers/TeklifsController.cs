using Application.Features.Teklifs.Commands.Create;
using Application.Features.Teklifs.Commands.Delete;
using Application.Features.Teklifs.Commands.Update;
using Application.Features.Teklifs.Queries.GetById;
using Application.Features.Teklifs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeklifsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTeklifResponse>> Add([FromBody] CreateTeklifCommand command)
    {
        CreatedTeklifResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTeklifResponse>> Update([FromBody] UpdateTeklifCommand command)
    {
        UpdatedTeklifResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTeklifResponse>> Delete([FromRoute] Guid id)
    {
        DeleteTeklifCommand command = new() { Id = id };

        DeletedTeklifResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTeklifResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdTeklifQuery query = new() { Id = id };

        GetByIdTeklifResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListTeklifQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTeklifQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTeklifListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}