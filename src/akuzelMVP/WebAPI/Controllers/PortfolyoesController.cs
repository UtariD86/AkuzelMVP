using Application.Features.Portfolyoes.Commands.Create;
using Application.Features.Portfolyoes.Commands.Delete;
using Application.Features.Portfolyoes.Commands.Update;
using Application.Features.Portfolyoes.Queries.GetById;
using Application.Features.Portfolyoes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PortfolyoesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPortfolyoResponse>> Add([FromBody] CreatePortfolyoCommand command)
    {
        CreatedPortfolyoResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPortfolyoResponse>> Update([FromBody] UpdatePortfolyoCommand command)
    {
        UpdatedPortfolyoResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPortfolyoResponse>> Delete([FromRoute] Guid id)
    {
        DeletePortfolyoCommand command = new() { Id = id };

        DeletedPortfolyoResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPortfolyoResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdPortfolyoQuery query = new() { Id = id };

        GetByIdPortfolyoResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPortfolyoQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPortfolyoQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPortfolyoListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}