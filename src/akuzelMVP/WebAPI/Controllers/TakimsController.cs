using Application.Features.Takims.Commands.Create;
using Application.Features.Takims.Commands.Delete;
using Application.Features.Takims.Commands.Update;
using Application.Features.Takims.Queries.GetById;
using Application.Features.Takims.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Takims.Queries.GetFilteredList;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TakimsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTakimResponse>> Add([FromBody] CreateTakimCommand command)
    {
        CreatedTakimResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTakimResponse>> Update([FromBody] UpdateTakimCommand command)
    {
        UpdatedTakimResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTakimResponse>> Delete([FromRoute] Guid id)
    {
        DeleteTakimCommand command = new() { Id = id };

        DeletedTakimResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTakimResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdTakimQuery query = new() { Id = id };

        GetByIdTakimResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("list", Name = "GetList")]
    public async Task<ActionResult<GetListTakimQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTakimQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTakimListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("filteredList", Name = "GetFilteredList")]
    public async Task<ActionResult<GetFilteredListTakimQuery>> GetFilteredList([FromQuery] PageRequest pageRequest, GetFilteredListTakimFilterDto filtreler)
    {
        GetFilteredListTakimQuery query = new() { PageRequest = pageRequest, Filtreler = filtreler };

        GetListResponse<GetFilteredListTakimListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

}