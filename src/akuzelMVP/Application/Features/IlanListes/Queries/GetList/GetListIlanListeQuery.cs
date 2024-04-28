using Application.Features.IlanListes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.IlanListes.Constants.IlanListesOperationClaims;

namespace Application.Features.IlanListes.Queries.GetList;

public class GetListIlanListeQuery : IRequest<GetListResponse<GetListIlanListeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListIlanListes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetIlanListes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListIlanListeQueryHandler : IRequestHandler<GetListIlanListeQuery, GetListResponse<GetListIlanListeListItemDto>>
    {
        private readonly IIlanListeRepository _ilanListeRepository;
        private readonly IMapper _mapper;

        public GetListIlanListeQueryHandler(IIlanListeRepository ilanListeRepository, IMapper mapper)
        {
            _ilanListeRepository = ilanListeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListIlanListeListItemDto>> Handle(GetListIlanListeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<IlanListe> ilanListes = await _ilanListeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListIlanListeListItemDto> response = _mapper.Map<GetListResponse<GetListIlanListeListItemDto>>(ilanListes);
            return response;
        }
    }
}