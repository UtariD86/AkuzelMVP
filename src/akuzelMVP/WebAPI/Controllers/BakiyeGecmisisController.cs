using Application.Features.BakiyeGecmisis.Commands.Create;
using Application.Features.BakiyeGecmisis.Commands.Delete;
using Application.Features.BakiyeGecmisis.Commands.Update;
using Application.Features.BakiyeGecmisis.Queries.GetById;
using Application.Features.BakiyeGecmisis.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BakiyeGecmisisController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedBakiyeGecmisiResponse>> Add([FromBody] CreateBakiyeGecmisiCommand command)
    {
        CreatedBakiyeGecmisiResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedBakiyeGecmisiResponse>> Update([FromBody] UpdateBakiyeGecmisiCommand command)
    {
        UpdatedBakiyeGecmisiResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedBakiyeGecmisiResponse>> Delete([FromRoute] Guid id)
    {
        DeleteBakiyeGecmisiCommand command = new() { Id = id };

        DeletedBakiyeGecmisiResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdBakiyeGecmisiResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdBakiyeGecmisiQuery query = new() { Id = id };

        GetByIdBakiyeGecmisiResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListBakiyeGecmisiQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBakiyeGecmisiQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListBakiyeGecmisiListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}