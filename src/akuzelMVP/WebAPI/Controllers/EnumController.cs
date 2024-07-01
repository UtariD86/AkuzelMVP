using Application.Features.Takims.Queries.GetFilteredList;
using Application.Features.Takims.Queries.GetList;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using System.Reflection;
using WebAPI.Controllers.Dtos;
using WebAPI.Helpers;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnumController : BaseController
{


    [HttpGet("getEnumList", Name = "GetEnumList")]
    public async Task<ActionResult<List<SelectListDto>>> GetEnumList(/*[FromQuery] PageRequest pageRequest,*/ int typeId)
    {
        var enumType = EnumHelper.GetEnumByTypeId(typeId);

        MethodInfo method = typeof(EnumHelper)
            .GetMethod(nameof(EnumHelper.GetEnumList))
            .MakeGenericMethod(enumType);

        var items = (List<SelectListDto>)method.Invoke(null, null);

        var response = new GetListResponse<SelectListDto>
        {
            Count = items.Count,
            HasNext = false, // Sayfalandırma varsa güncellenmeli
            HasPrevious = false, // Sayfalandırma varsa güncellenmeli
            Index = 0, // Sayfa indeksi
            Items = items
        };

        return Ok(response);
    }


}

