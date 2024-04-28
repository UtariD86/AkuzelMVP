using Application.Features.BankaHesaps.Commands.Create;
using Application.Features.BankaHesaps.Commands.Delete;
using Application.Features.BankaHesaps.Commands.Update;
using Application.Features.BankaHesaps.Queries.GetById;
using Application.Features.BankaHesaps.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BankaHesapsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedBankaHesapResponse>> Add([FromBody] CreateBankaHesapCommand command)
    {
        CreatedBankaHesapResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedBankaHesapResponse>> Update([FromBody] UpdateBankaHesapCommand command)
    {
        UpdatedBankaHesapResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedBankaHesapResponse>> Delete([FromRoute] Guid id)
    {
        DeleteBankaHesapCommand command = new() { Id = id };

        DeletedBankaHesapResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdBankaHesapResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdBankaHesapQuery query = new() { Id = id };

        GetByIdBankaHesapResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListBankaHesapQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBankaHesapQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListBankaHesapListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}