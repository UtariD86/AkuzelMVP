using Application.Features.Teklifs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Teklifs.Constants.TeklifsOperationClaims;

namespace Application.Features.Teklifs.Queries.GetList;

public class GetListTeklifQuery : IRequest<GetListResponse<GetListTeklifListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTeklifs({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTeklifs";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTeklifQueryHandler : IRequestHandler<GetListTeklifQuery, GetListResponse<GetListTeklifListItemDto>>
    {
        private readonly ITeklifRepository _teklifRepository;
        private readonly IMapper _mapper;

        public GetListTeklifQueryHandler(ITeklifRepository teklifRepository, IMapper mapper)
        {
            _teklifRepository = teklifRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTeklifListItemDto>> Handle(GetListTeklifQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Teklif> teklifs = await _teklifRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTeklifListItemDto> response = _mapper.Map<GetListResponse<GetListTeklifListItemDto>>(teklifs);
            return response;
        }
    }
}