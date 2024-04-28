using Application.Features.Listes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Listes.Constants.ListesOperationClaims;

namespace Application.Features.Listes.Queries.GetList;

public class GetListListeQuery : IRequest<GetListResponse<GetListListeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListListes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetListes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListListeQueryHandler : IRequestHandler<GetListListeQuery, GetListResponse<GetListListeListItemDto>>
    {
        private readonly IListeRepository _listeRepository;
        private readonly IMapper _mapper;

        public GetListListeQueryHandler(IListeRepository listeRepository, IMapper mapper)
        {
            _listeRepository = listeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListListeListItemDto>> Handle(GetListListeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Liste> listes = await _listeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListListeListItemDto> response = _mapper.Map<GetListResponse<GetListListeListItemDto>>(listes);
            return response;
        }
    }
}