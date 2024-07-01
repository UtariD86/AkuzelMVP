using Application.Features.Takims.Commands.Create;
using Application.Features.Takims.Commands.Delete;
using Application.Features.Takims.Commands.Update;
using Application.Features.Takims.Queries.GetById;
using Application.Features.Takims.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Takims.Queries.GetFilteredList;

namespace Application.Features.Takims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTakimCommand, Takim>();
        CreateMap<Takim, CreatedTakimResponse>();

        CreateMap<UpdateTakimCommand, Takim>();
        CreateMap<Takim, UpdatedTakimResponse>();

        CreateMap<DeleteTakimCommand, Takim>();
        CreateMap<Takim, DeletedTakimResponse>();

        CreateMap<Takim, GetByIdTakimResponse>();

        CreateMap<Takim, GetListTakimListItemDto>();
        CreateMap<IPaginate<Takim>, GetListResponse<GetListTakimListItemDto>>();

        CreateMap<Takim, GetFilteredListTakimListItemDto>();
        CreateMap<IPaginate<Takim>, GetListResponse<GetFilteredListTakimListItemDto>>();
    }
}