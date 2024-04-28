using Application.Features.Ilans.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Ilans.Constants.IlansOperationClaims;

namespace Application.Features.Ilans.Queries.GetList;

public class GetListIlanQuery : IRequest<GetListResponse<GetListIlanListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListIlans({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetIlans";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListIlanQueryHandler : IRequestHandler<GetListIlanQuery, GetListResponse<GetListIlanListItemDto>>
    {
        private readonly IIlanRepository _ilanRepository;
        private readonly IMapper _mapper;

        public GetListIlanQueryHandler(IIlanRepository ilanRepository, IMapper mapper)
        {
            _ilanRepository = ilanRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListIlanListItemDto>> Handle(GetListIlanQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Ilan> ilans = await _ilanRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListIlanListItemDto> response = _mapper.Map<GetListResponse<GetListIlanListItemDto>>(ilans);
            return response;
        }
    }
}