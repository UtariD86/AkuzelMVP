using Application.Features.Ilans.Commands.Create;
using Application.Features.Ilans.Commands.Delete;
using Application.Features.Ilans.Commands.Update;
using Application.Features.Ilans.Queries.GetById;
using Application.Features.Ilans.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Ilans.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateIlanCommand, Ilan>();
        CreateMap<Ilan, CreatedIlanResponse>();

        CreateMap<UpdateIlanCommand, Ilan>();
        CreateMap<Ilan, UpdatedIlanResponse>();

        CreateMap<DeleteIlanCommand, Ilan>();
        CreateMap<Ilan, DeletedIlanResponse>();

        CreateMap<Ilan, GetByIdIlanResponse>();

        CreateMap<Ilan, GetListIlanListItemDto>();
        CreateMap<IPaginate<Ilan>, GetListResponse<GetListIlanListItemDto>>();
    }
}