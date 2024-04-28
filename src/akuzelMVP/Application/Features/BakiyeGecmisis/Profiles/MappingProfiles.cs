using Application.Features.BakiyeGecmisis.Commands.Create;
using Application.Features.BakiyeGecmisis.Commands.Delete;
using Application.Features.BakiyeGecmisis.Commands.Update;
using Application.Features.BakiyeGecmisis.Queries.GetById;
using Application.Features.BakiyeGecmisis.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BakiyeGecmisis.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBakiyeGecmisiCommand, BakiyeGecmisi>();
        CreateMap<BakiyeGecmisi, CreatedBakiyeGecmisiResponse>();

        CreateMap<UpdateBakiyeGecmisiCommand, BakiyeGecmisi>();
        CreateMap<BakiyeGecmisi, UpdatedBakiyeGecmisiResponse>();

        CreateMap<DeleteBakiyeGecmisiCommand, BakiyeGecmisi>();
        CreateMap<BakiyeGecmisi, DeletedBakiyeGecmisiResponse>();

        CreateMap<BakiyeGecmisi, GetByIdBakiyeGecmisiResponse>();

        CreateMap<BakiyeGecmisi, GetListBakiyeGecmisiListItemDto>();
        CreateMap<IPaginate<BakiyeGecmisi>, GetListResponse<GetListBakiyeGecmisiListItemDto>>();
    }
}