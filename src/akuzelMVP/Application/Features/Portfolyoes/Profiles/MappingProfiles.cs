using Application.Features.Portfolyoes.Commands.Create;
using Application.Features.Portfolyoes.Commands.Delete;
using Application.Features.Portfolyoes.Commands.Update;
using Application.Features.Portfolyoes.Queries.GetById;
using Application.Features.Portfolyoes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Portfolyoes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePortfolyoCommand, Portfolyo>();
        CreateMap<Portfolyo, CreatedPortfolyoResponse>();

        CreateMap<UpdatePortfolyoCommand, Portfolyo>();
        CreateMap<Portfolyo, UpdatedPortfolyoResponse>();

        CreateMap<DeletePortfolyoCommand, Portfolyo>();
        CreateMap<Portfolyo, DeletedPortfolyoResponse>();

        CreateMap<Portfolyo, GetByIdPortfolyoResponse>();

        CreateMap<Portfolyo, GetListPortfolyoListItemDto>();
        CreateMap<IPaginate<Portfolyo>, GetListResponse<GetListPortfolyoListItemDto>>();
    }
}