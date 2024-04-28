using Application.Features.Mesajs.Commands.Create;
using Application.Features.Mesajs.Commands.Delete;
using Application.Features.Mesajs.Commands.Update;
using Application.Features.Mesajs.Queries.GetById;
using Application.Features.Mesajs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Mesajs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateMesajCommand, Mesaj>();
        CreateMap<Mesaj, CreatedMesajResponse>();

        CreateMap<UpdateMesajCommand, Mesaj>();
        CreateMap<Mesaj, UpdatedMesajResponse>();

        CreateMap<DeleteMesajCommand, Mesaj>();
        CreateMap<Mesaj, DeletedMesajResponse>();

        CreateMap<Mesaj, GetByIdMesajResponse>();

        CreateMap<Mesaj, GetListMesajListItemDto>();
        CreateMap<IPaginate<Mesaj>, GetListResponse<GetListMesajListItemDto>>();
    }
}