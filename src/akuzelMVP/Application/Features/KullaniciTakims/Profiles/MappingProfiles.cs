using Application.Features.KullaniciTakims.Commands.Create;
using Application.Features.KullaniciTakims.Commands.Delete;
using Application.Features.KullaniciTakims.Commands.Update;
using Application.Features.KullaniciTakims.Queries.GetById;
using Application.Features.KullaniciTakims.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.KullaniciTakims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateKullaniciTakimCommand, KullaniciTakim>();
        CreateMap<KullaniciTakim, CreatedKullaniciTakimResponse>();

        CreateMap<UpdateKullaniciTakimCommand, KullaniciTakim>();
        CreateMap<KullaniciTakim, UpdatedKullaniciTakimResponse>();

        CreateMap<DeleteKullaniciTakimCommand, KullaniciTakim>();
        CreateMap<KullaniciTakim, DeletedKullaniciTakimResponse>();

        CreateMap<KullaniciTakim, GetByIdKullaniciTakimResponse>();

        CreateMap<KullaniciTakim, GetListKullaniciTakimListItemDto>();
        CreateMap<IPaginate<KullaniciTakim>, GetListResponse<GetListKullaniciTakimListItemDto>>();
    }
}