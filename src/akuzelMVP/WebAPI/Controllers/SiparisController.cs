using Application.Features.Siparis.Commands.Create;
using Application.Features.Siparis.Commands.Delete;
using Application.Features.Siparis.Commands.Update;
using Application.Features.Siparis.Queries.GetById;
using Application.Features.Siparis.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SiparisController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSiparisResponse>> Add([FromBody] CreateSiparisCommand command)
    {
        CreatedSiparisResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSiparisResponse>> Update([FromBody] UpdateSiparisCommand command)
    {
        UpdatedSiparisResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSiparisResponse>> Delete([FromRoute] Guid id)
    {
        DeleteSiparisCommand command = new() { Id = id };

        DeletedSiparisResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSiparisResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdSiparisQuery query = new() { Id = id };

        GetByIdSiparisResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSiparisQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSiparisQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSiparisListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}