using Application.Features.Tickets.Commands.Create;
using Application.Features.Tickets.Commands.Delete;
using Application.Features.Tickets.Commands.Update;
using Application.Features.Tickets.Queries.GetById;
using Application.Features.Tickets.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTicketResponse>> Add([FromBody] CreateTicketCommand command)
    {
        CreatedTicketResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTicketResponse>> Update([FromBody] UpdateTicketCommand command)
    {
        UpdatedTicketResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTicketResponse>> Delete([FromRoute] Guid id)
    {
        DeleteTicketCommand command = new() { Id = id };

        DeletedTicketResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTicketResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdTicketQuery query = new() { Id = id };

        GetByIdTicketResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListTicketQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTicketQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTicketListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}