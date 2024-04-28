using Application.Features.Bildirims.Commands.Create;
using Application.Features.Bildirims.Commands.Delete;
using Application.Features.Bildirims.Commands.Update;
using Application.Features.Bildirims.Queries.GetById;
using Application.Features.Bildirims.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Bildirims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBildirimCommand, Bildirim>();
        CreateMap<Bildirim, CreatedBildirimResponse>();

        CreateMap<UpdateBildirimCommand, Bildirim>();
        CreateMap<Bildirim, UpdatedBildirimResponse>();

        CreateMap<DeleteBildirimCommand, Bildirim>();
        CreateMap<Bildirim, DeletedBildirimResponse>();

        CreateMap<Bildirim, GetByIdBildirimResponse>();

        CreateMap<Bildirim, GetListBildirimListItemDto>();
        CreateMap<IPaginate<Bildirim>, GetListResponse<GetListBildirimListItemDto>>();
    }
}