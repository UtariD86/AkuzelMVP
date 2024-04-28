using Application.Features.BankaHesaps.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.BankaHesaps.Constants.BankaHesapsOperationClaims;

namespace Application.Features.BankaHesaps.Queries.GetList;

public class GetListBankaHesapQuery : IRequest<GetListResponse<GetListBankaHesapListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBankaHesaps({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBankaHesaps";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBankaHesapQueryHandler : IRequestHandler<GetListBankaHesapQuery, GetListResponse<GetListBankaHesapListItemDto>>
    {
        private readonly IBankaHesapRepository _bankaHesapRepository;
        private readonly IMapper _mapper;

        public GetListBankaHesapQueryHandler(IBankaHesapRepository bankaHesapRepository, IMapper mapper)
        {
            _bankaHesapRepository = bankaHesapRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBankaHesapListItemDto>> Handle(GetListBankaHesapQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BankaHesap> bankaHesaps = await _bankaHesapRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBankaHesapListItemDto> response = _mapper.Map<GetListResponse<GetListBankaHesapListItemDto>>(bankaHesaps);
            return response;
        }
    }
}