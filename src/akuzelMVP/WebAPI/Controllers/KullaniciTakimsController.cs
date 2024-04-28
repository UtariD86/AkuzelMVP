using Application.Features.KullaniciTakims.Commands.Create;
using Application.Features.KullaniciTakims.Commands.Delete;
using Application.Features.KullaniciTakims.Commands.Update;
using Application.Features.KullaniciTakims.Queries.GetById;
using Application.Features.KullaniciTakims.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KullaniciTakimsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedKullaniciTakimResponse>> Add([FromBody] CreateKullaniciTakimCommand command)
    {
        CreatedKullaniciTakimResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedKullaniciTakimResponse>> Update([FromBody] UpdateKullaniciTakimCommand command)
    {
        UpdatedKullaniciTakimResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedKullaniciTakimResponse>> Delete([FromRoute] Guid id)
    {
        DeleteKullaniciTakimCommand command = new() { Id = id };

        DeletedKullaniciTakimResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdKullaniciTakimResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdKullaniciTakimQuery query = new() { Id = id };

        GetByIdKullaniciTakimResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListKullaniciTakimQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListKullaniciTakimQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListKullaniciTakimListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}