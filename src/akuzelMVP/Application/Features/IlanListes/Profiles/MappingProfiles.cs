using Application.Features.IlanListes.Commands.Create;
using Application.Features.IlanListes.Commands.Delete;
using Application.Features.IlanListes.Commands.Update;
using Application.Features.IlanListes.Queries.GetById;
using Application.Features.IlanListes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.IlanListes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateIlanListeCommand, IlanListe>();
        CreateMap<IlanListe, CreatedIlanListeResponse>();

        CreateMap<UpdateIlanListeCommand, IlanListe>();
        CreateMap<IlanListe, UpdatedIlanListeResponse>();

        CreateMap<DeleteIlanListeCommand, IlanListe>();
        CreateMap<IlanListe, DeletedIlanListeResponse>();

        CreateMap<IlanListe, GetByIdIlanListeResponse>();

        CreateMap<IlanListe, GetListIlanListeListItemDto>();
        CreateMap<IPaginate<IlanListe>, GetListResponse<GetListIlanListeListItemDto>>();
    }
}