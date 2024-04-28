using Application.Features.KullaniciAyars.Commands.Create;
using Application.Features.KullaniciAyars.Commands.Delete;
using Application.Features.KullaniciAyars.Commands.Update;
using Application.Features.KullaniciAyars.Queries.GetById;
using Application.Features.KullaniciAyars.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.KullaniciAyars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateKullaniciAyarCommand, KullaniciAyar>();
        CreateMap<KullaniciAyar, CreatedKullaniciAyarResponse>();

        CreateMap<UpdateKullaniciAyarCommand, KullaniciAyar>();
        CreateMap<KullaniciAyar, UpdatedKullaniciAyarResponse>();

        CreateMap<DeleteKullaniciAyarCommand, KullaniciAyar>();
        CreateMap<KullaniciAyar, DeletedKullaniciAyarResponse>();

        CreateMap<KullaniciAyar, GetByIdKullaniciAyarResponse>();

        CreateMap<KullaniciAyar, GetListKullaniciAyarListItemDto>();
        CreateMap<IPaginate<KullaniciAyar>, GetListResponse<GetListKullaniciAyarListItemDto>>();
    }
}