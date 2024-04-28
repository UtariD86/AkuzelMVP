using Application.Features.ListeVeris.Commands.Create;
using Application.Features.ListeVeris.Commands.Delete;
using Application.Features.ListeVeris.Commands.Update;
using Application.Features.ListeVeris.Queries.GetById;
using Application.Features.ListeVeris.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ListeVeris.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateListeVeriCommand, ListeVeri>();
        CreateMap<ListeVeri, CreatedListeVeriResponse>();

        CreateMap<UpdateListeVeriCommand, ListeVeri>();
        CreateMap<ListeVeri, UpdatedListeVeriResponse>();

        CreateMap<DeleteListeVeriCommand, ListeVeri>();
        CreateMap<ListeVeri, DeletedListeVeriResponse>();

        CreateMap<ListeVeri, GetByIdListeVeriResponse>();

        CreateMap<ListeVeri, GetListListeVeriListItemDto>();
        CreateMap<IPaginate<ListeVeri>, GetListResponse<GetListListeVeriListItemDto>>();
    }
}