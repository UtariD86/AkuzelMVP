using Application.Features.Teklifs.Commands.Create;
using Application.Features.Teklifs.Commands.Delete;
using Application.Features.Teklifs.Commands.Update;
using Application.Features.Teklifs.Queries.GetById;
using Application.Features.Teklifs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Teklifs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTeklifCommand, Teklif>();
        CreateMap<Teklif, CreatedTeklifResponse>();

        CreateMap<UpdateTeklifCommand, Teklif>();
        CreateMap<Teklif, UpdatedTeklifResponse>();

        CreateMap<DeleteTeklifCommand, Teklif>();
        CreateMap<Teklif, DeletedTeklifResponse>();

        CreateMap<Teklif, GetByIdTeklifResponse>();

        CreateMap<Teklif, GetListTeklifListItemDto>();
        CreateMap<IPaginate<Teklif>, GetListResponse<GetListTeklifListItemDto>>();
    }
}