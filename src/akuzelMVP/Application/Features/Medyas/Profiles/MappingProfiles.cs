using Application.Features.Medyas.Commands.Create;
using Application.Features.Medyas.Commands.Delete;
using Application.Features.Medyas.Commands.Update;
using Application.Features.Medyas.Queries.GetById;
using Application.Features.Medyas.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Medyas.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateMedyaCommand, Medya>();
        CreateMap<Medya, CreatedMedyaResponse>();

        CreateMap<UpdateMedyaCommand, Medya>();
        CreateMap<Medya, UpdatedMedyaResponse>();

        CreateMap<DeleteMedyaCommand, Medya>();
        CreateMap<Medya, DeletedMedyaResponse>();

        CreateMap<Medya, GetByIdMedyaResponse>();

        CreateMap<Medya, GetListMedyaListItemDto>();
        CreateMap<IPaginate<Medya>, GetListResponse<GetListMedyaListItemDto>>();
    }
}