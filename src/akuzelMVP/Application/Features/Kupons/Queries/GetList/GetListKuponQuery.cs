using Application.Features.Kupons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Kupons.Constants.KuponsOperationClaims;

namespace Application.Features.Kupons.Queries.GetList;

public class GetListKuponQuery : IRequest<GetListResponse<GetListKuponListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListKupons({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetKupons";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListKuponQueryHandler : IRequestHandler<GetListKuponQuery, GetListResponse<GetListKuponListItemDto>>
    {
        private readonly IKuponRepository _kuponRepository;
        private readonly IMapper _mapper;

        public GetListKuponQueryHandler(IKuponRepository kuponRepository, IMapper mapper)
        {
            _kuponRepository = kuponRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListKuponListItemDto>> Handle(GetListKuponQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Kupon> kupons = await _kuponRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListKuponListItemDto> response = _mapper.Map<GetListResponse<GetListKuponListItemDto>>(kupons);
            return response;
        }
    }
}