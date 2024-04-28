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
        CreateMap<CreateSiparisCommand, Domain.Entities.Siparis>();
        CreateMap<Domain.Entities.Siparis, CreatedSiparisResponse>();

        CreateMap<UpdateSiparisCommand, Domain.Entities.Siparis>();
        CreateMap<Domain.Entities.Siparis, UpdatedSiparisResponse>();

        CreateMap<DeleteSiparisCommand, Domain.Entities.Siparis>();
        CreateMap<Domain.Entities.Siparis, DeletedSiparisResponse>();

        CreateMap<Domain.Entities.Siparis, GetByIdSiparisResponse>();

        CreateMap<Domain.Entities.Siparis, GetListSiparisListItemDto>();
        CreateMap<IPaginate<Domain.Entities.Siparis>, GetListResponse<GetListSiparisListItemDto>>();
    }
}