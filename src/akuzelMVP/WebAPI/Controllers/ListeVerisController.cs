using Application.Features.ListeVeris.Commands.Create;
using Application.Features.ListeVeris.Commands.Delete;
using Application.Features.ListeVeris.Commands.Update;
using Application.Features.ListeVeris.Queries.GetById;
using Application.Features.ListeVeris.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ListeVerisController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedListeVeriResponse>> Add([FromBody] CreateListeVeriCommand command)
    {
        CreatedListeVeriResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedListeVeriResponse>> Update([FromBody] UpdateListeVeriCommand command)
    {
        UpdatedListeVeriResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedListeVeriResponse>> Delete([FromRoute] Guid id)
    {
        DeleteListeVeriCommand command = new() { Id = id };

        DeletedListeVeriResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdListeVeriResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdListeVeriQuery query = new() { Id = id };

        GetByIdListeVeriResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListListeVeriQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListListeVeriQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListListeVeriListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}