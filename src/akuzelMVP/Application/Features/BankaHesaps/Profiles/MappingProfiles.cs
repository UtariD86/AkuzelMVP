using Application.Features.BankaHesaps.Commands.Create;
using Application.Features.BankaHesaps.Commands.Delete;
using Application.Features.BankaHesaps.Commands.Update;
using Application.Features.BankaHesaps.Queries.GetById;
using Application.Features.BankaHesaps.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BankaHesaps.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBankaHesapCommand, BankaHesap>();
        CreateMap<BankaHesap, CreatedBankaHesapResponse>();

        CreateMap<UpdateBankaHesapCommand, BankaHesap>();
        CreateMap<BankaHesap, UpdatedBankaHesapResponse>();

        CreateMap<DeleteBankaHesapCommand, BankaHesap>();
        CreateMap<BankaHesap, DeletedBankaHesapResponse>();

        CreateMap<BankaHesap, GetByIdBankaHesapResponse>();

        CreateMap<BankaHesap, GetListBankaHesapListItemDto>();
        CreateMap<IPaginate<BankaHesap>, GetListResponse<GetListBankaHesapListItemDto>>();
    }
}