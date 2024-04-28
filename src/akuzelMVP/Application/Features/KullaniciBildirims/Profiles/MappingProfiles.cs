using Application.Features.KullaniciBildirims.Commands.Create;
using Application.Features.KullaniciBildirims.Commands.Delete;
using Application.Features.KullaniciBildirims.Commands.Update;
using Application.Features.KullaniciBildirims.Queries.GetById;
using Application.Features.KullaniciBildirims.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.KullaniciBildirims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateKullaniciBildirimCommand, KullaniciBildirim>();
        CreateMap<KullaniciBildirim, CreatedKullaniciBildirimResponse>();

        CreateMap<UpdateKullaniciBildirimCommand, KullaniciBildirim>();
        CreateMap<KullaniciBildirim, UpdatedKullaniciBildirimResponse>();

        CreateMap<DeleteKullaniciBildirimCommand, KullaniciBildirim>();
        CreateMap<KullaniciBildirim, DeletedKullaniciBildirimResponse>();

        CreateMap<KullaniciBildirim, GetByIdKullaniciBildirimResponse>();

        CreateMap<KullaniciBildirim, GetListKullaniciBildirimListItemDto>();
        CreateMap<IPaginate<KullaniciBildirim>, GetListResponse<GetListKullaniciBildirimListItemDto>>();
    }
}