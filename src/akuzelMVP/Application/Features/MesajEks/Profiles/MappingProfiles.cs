using Application.Features.MesajEks.Commands.Create;
using Application.Features.MesajEks.Commands.Delete;
using Application.Features.MesajEks.Commands.Update;
using Application.Features.MesajEks.Queries.GetById;
using Application.Features.MesajEks.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MesajEks.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateMesajEkCommand, MesajEk>();
        CreateMap<MesajEk, CreatedMesajEkResponse>();

        CreateMap<UpdateMesajEkCommand, MesajEk>();
        CreateMap<MesajEk, UpdatedMesajEkResponse>();

        CreateMap<DeleteMesajEkCommand, MesajEk>();
        CreateMap<MesajEk, DeletedMesajEkResponse>();

        CreateMap<MesajEk, GetByIdMesajEkResponse>();

        CreateMap<MesajEk, GetListMesajEkListItemDto>();
        CreateMap<IPaginate<MesajEk>, GetListResponse<GetListMesajEkListItemDto>>();
    }
}