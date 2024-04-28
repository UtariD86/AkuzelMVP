using Application.Features.SistemGecmisis.Commands.Create;
using Application.Features.SistemGecmisis.Commands.Delete;
using Application.Features.SistemGecmisis.Commands.Update;
using Application.Features.SistemGecmisis.Queries.GetById;
using Application.Features.SistemGecmisis.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SistemGecmisis.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSistemGecmisiCommand, SistemGecmisi>();
        CreateMap<SistemGecmisi, CreatedSistemGecmisiResponse>();

        CreateMap<UpdateSistemGecmisiCommand, SistemGecmisi>();
        CreateMap<SistemGecmisi, UpdatedSistemGecmisiResponse>();

        CreateMap<DeleteSistemGecmisiCommand, SistemGecmisi>();
        CreateMap<SistemGecmisi, DeletedSistemGecmisiResponse>();

        CreateMap<SistemGecmisi, GetByIdSistemGecmisiResponse>();

        CreateMap<SistemGecmisi, GetListSistemGecmisiListItemDto>();
        CreateMap<IPaginate<SistemGecmisi>, GetListResponse<GetListSistemGecmisiListItemDto>>();
    }
}