using Application.Features.Siparis.Commands.Create;
using Application.Features.Siparis.Commands.Delete;
using Application.Features.Siparis.Commands.Update;
using Application.Features.Siparis.Queries.GetById;
using Application.Features.Siparis.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Siparis.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSiparisCommand, Siparis>();
        CreateMap<Siparis, CreatedSiparisResponse>();

        CreateMap<UpdateSiparisCommand, Siparis>();
        CreateMap<Siparis, UpdatedSiparisResponse>();

        CreateMap<DeleteSiparisCommand, Siparis>();
        CreateMap<Siparis, DeletedSiparisResponse>();

        CreateMap<Siparis, GetByIdSiparisResponse>();

        CreateMap<Siparis, GetListSiparisListItemDto>();
        CreateMap<IPaginate<Siparis>, GetListResponse<GetListSiparisListItemDto>>();
    }
}