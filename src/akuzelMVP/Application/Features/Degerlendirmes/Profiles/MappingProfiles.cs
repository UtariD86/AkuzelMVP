using Application.Features.Degerlendirmes.Commands.Create;
using Application.Features.Degerlendirmes.Commands.Delete;
using Application.Features.Degerlendirmes.Commands.Update;
using Application.Features.Degerlendirmes.Queries.GetById;
using Application.Features.Degerlendirmes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Degerlendirmes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDegerlendirmeCommand, Degerlendirme>();
        CreateMap<Degerlendirme, CreatedDegerlendirmeResponse>();

        CreateMap<UpdateDegerlendirmeCommand, Degerlendirme>();
        CreateMap<Degerlendirme, UpdatedDegerlendirmeResponse>();

        CreateMap<DeleteDegerlendirmeCommand, Degerlendirme>();
        CreateMap<Degerlendirme, DeletedDegerlendirmeResponse>();

        CreateMap<Degerlendirme, GetByIdDegerlendirmeResponse>();

        CreateMap<Degerlendirme, GetListDegerlendirmeListItemDto>();
        CreateMap<IPaginate<Degerlendirme>, GetListResponse<GetListDegerlendirmeListItemDto>>();
    }
}