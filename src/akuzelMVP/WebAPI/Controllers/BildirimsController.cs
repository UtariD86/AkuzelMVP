using Application.Features.Bildirims.Commands.Create;
using Application.Features.Bildirims.Commands.Delete;
using Application.Features.Bildirims.Commands.Update;
using Application.Features.Bildirims.Queries.GetById;
using Application.Features.Bildirims.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BildirimsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedBildirimResponse>> Add([FromBody] CreateBildirimCommand command)
    {
        CreatedBildirimResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedBildirimResponse>> Update([FromBody] UpdateBildirimCommand command)
    {
        UpdatedBildirimResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedBildirimResponse>> Delete([FromRoute] Guid id)
    {
        DeleteBildirimCommand command = new() { Id = id };

        DeletedBildirimResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdBildirimResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdBildirimQuery query = new() { Id = id };

        GetByIdBildirimResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListBildirimQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBildirimQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListBildirimListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}