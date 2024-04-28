using Application.Features.KullaniciAyars.Commands.Create;
using Application.Features.KullaniciAyars.Commands.Delete;
using Application.Features.KullaniciAyars.Commands.Update;
using Application.Features.KullaniciAyars.Queries.GetById;
using Application.Features.KullaniciAyars.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KullaniciAyarsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedKullaniciAyarResponse>> Add([FromBody] CreateKullaniciAyarCommand command)
    {
        CreatedKullaniciAyarResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedKullaniciAyarResponse>> Update([FromBody] UpdateKullaniciAyarCommand command)
    {
        UpdatedKullaniciAyarResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedKullaniciAyarResponse>> Delete([FromRoute] Guid id)
    {
        DeleteKullaniciAyarCommand command = new() { Id = id };

        DeletedKullaniciAyarResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdKullaniciAyarResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdKullaniciAyarQuery query = new() { Id = id };

        GetByIdKullaniciAyarResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListKullaniciAyarQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListKullaniciAyarQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListKullaniciAyarListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}