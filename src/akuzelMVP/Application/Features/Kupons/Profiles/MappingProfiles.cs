using Application.Features.Kupons.Commands.Create;
using Application.Features.Kupons.Commands.Delete;
using Application.Features.Kupons.Commands.Update;
using Application.Features.Kupons.Queries.GetById;
using Application.Features.Kupons.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Kupons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateKuponCommand, Kupon>();
        CreateMap<Kupon, CreatedKuponResponse>();

        CreateMap<UpdateKuponCommand, Kupon>();
        CreateMap<Kupon, UpdatedKuponResponse>();

        CreateMap<DeleteKuponCommand, Kupon>();
        CreateMap<Kupon, DeletedKuponResponse>();

        CreateMap<Kupon, GetByIdKuponResponse>();

        CreateMap<Kupon, GetListKuponListItemDto>();
        CreateMap<IPaginate<Kupon>, GetListResponse<GetListKuponListItemDto>>();
    }
}