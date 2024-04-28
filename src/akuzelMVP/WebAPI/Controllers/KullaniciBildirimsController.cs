using Application.Features.KullaniciBildirims.Commands.Create;
using Application.Features.KullaniciBildirims.Commands.Delete;
using Application.Features.KullaniciBildirims.Commands.Update;
using Application.Features.KullaniciBildirims.Queries.GetById;
using Application.Features.KullaniciBildirims.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KullaniciBildirimsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedKullaniciBildirimResponse>> Add([FromBody] CreateKullaniciBildirimCommand command)
    {
        CreatedKullaniciBildirimResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedKullaniciBildirimResponse>> Update([FromBody] UpdateKullaniciBildirimCommand command)
    {
        UpdatedKullaniciBildirimResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedKullaniciBildirimResponse>> Delete([FromRoute] Guid id)
    {
        DeleteKullaniciBildirimCommand command = new() { Id = id };

        DeletedKullaniciBildirimResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdKullaniciBildirimResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdKullaniciBildirimQuery query = new() { Id = id };

        GetByIdKullaniciBildirimResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListKullaniciBildirimQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListKullaniciBildirimQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListKullaniciBildirimListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}