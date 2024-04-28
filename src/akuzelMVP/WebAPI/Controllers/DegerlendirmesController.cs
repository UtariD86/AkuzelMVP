using Application.Features.Degerlendirmes.Commands.Create;
using Application.Features.Degerlendirmes.Commands.Delete;
using Application.Features.Degerlendirmes.Commands.Update;
using Application.Features.Degerlendirmes.Queries.GetById;
using Application.Features.Degerlendirmes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DegerlendirmesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDegerlendirmeResponse>> Add([FromBody] CreateDegerlendirmeCommand command)
    {
        CreatedDegerlendirmeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDegerlendirmeResponse>> Update([FromBody] UpdateDegerlendirmeCommand command)
    {
        UpdatedDegerlendirmeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDegerlendirmeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDegerlendirmeCommand command = new() { Id = id };

        DeletedDegerlendirmeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDegerlendirmeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDegerlendirmeQuery query = new() { Id = id };

        GetByIdDegerlendirmeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListDegerlendirmeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDegerlendirmeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDegerlendirmeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}