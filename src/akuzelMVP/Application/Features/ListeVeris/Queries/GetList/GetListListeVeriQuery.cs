using Application.Features.ListeVeris.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ListeVeris.Constants.ListeVerisOperationClaims;

namespace Application.Features.ListeVeris.Queries.GetList;

public class GetListListeVeriQuery : IRequest<GetListResponse<GetListListeVeriListItemDto>>, /*ISecuredRequest,*/ ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListListeVeris({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetListeVeris";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListListeVeriQueryHandler : IRequestHandler<GetListListeVeriQuery, GetListResponse<GetListListeVeriListItemDto>>
    {
        private readonly IListeVeriRepository _listeVeriRepository;
        private readonly IMapper _mapper;

        public GetListListeVeriQueryHandler(IListeVeriRepository listeVeriRepository, IMapper mapper)
        {
            _listeVeriRepository = listeVeriRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListListeVeriListItemDto>> Handle(GetListListeVeriQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ListeVeri> listeVeris = await _listeVeriRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListListeVeriListItemDto> response = _mapper.Map<GetListResponse<GetListListeVeriListItemDto>>(listeVeris);
            return response;
        }
    }
}