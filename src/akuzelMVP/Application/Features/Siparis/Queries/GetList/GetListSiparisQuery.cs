using Application.Features.Siparis.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Siparis.Constants.SiparisOperationClaims;

namespace Application.Features.Siparis.Queries.GetList;

public class GetListSiparisQuery : IRequest<GetListResponse<GetListSiparisListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListSiparis({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSiparis";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSiparisQueryHandler : IRequestHandler<GetListSiparisQuery, GetListResponse<GetListSiparisListItemDto>>
    {
        private readonly ISiparisRepository _siparisRepository;
        private readonly IMapper _mapper;

        public GetListSiparisQueryHandler(ISiparisRepository siparisRepository, IMapper mapper)
        {
            _siparisRepository = siparisRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSiparisListItemDto>> Handle(GetListSiparisQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Siparis> siparis = await _siparisRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSiparisListItemDto> response = _mapper.Map<GetListResponse<GetListSiparisListItemDto>>(siparis);
            return response;
        }
    }
}