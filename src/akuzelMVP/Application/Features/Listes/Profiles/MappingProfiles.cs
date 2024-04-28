using Application.Features.Listes.Commands.Create;
using Application.Features.Listes.Commands.Delete;
using Application.Features.Listes.Commands.Update;
using Application.Features.Listes.Queries.GetById;
using Application.Features.Listes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Listes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateListeCommand, Liste>();
        CreateMap<Liste, CreatedListeResponse>();

        CreateMap<UpdateListeCommand, Liste>();
        CreateMap<Liste, UpdatedListeResponse>();

        CreateMap<DeleteListeCommand, Liste>();
        CreateMap<Liste, DeletedListeResponse>();

        CreateMap<Liste, GetByIdListeResponse>();

        CreateMap<Liste, GetListListeListItemDto>();
        CreateMap<IPaginate<Liste>, GetListResponse<GetListListeListItemDto>>();
    }
}