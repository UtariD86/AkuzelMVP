using Application.Features.BakiyeGecmisis.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.BakiyeGecmisis.Constants.BakiyeGecmisisOperationClaims;

namespace Application.Features.BakiyeGecmisis.Queries.GetList;

public class GetListBakiyeGecmisiQuery : IRequest<GetListResponse<GetListBakiyeGecmisiListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBakiyeGecmisis({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBakiyeGecmisis";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBakiyeGecmisiQueryHandler : IRequestHandler<GetListBakiyeGecmisiQuery, GetListResponse<GetListBakiyeGecmisiListItemDto>>
    {
        private readonly IBakiyeGecmisiRepository _bakiyeGecmisiRepository;
        private readonly IMapper _mapper;

        public GetListBakiyeGecmisiQueryHandler(IBakiyeGecmisiRepository bakiyeGecmisiRepository, IMapper mapper)
        {
            _bakiyeGecmisiRepository = bakiyeGecmisiRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBakiyeGecmisiListItemDto>> Handle(GetListBakiyeGecmisiQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BakiyeGecmisi> bakiyeGecmisis = await _bakiyeGecmisiRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBakiyeGecmisiListItemDto> response = _mapper.Map<GetListResponse<GetListBakiyeGecmisiListItemDto>>(bakiyeGecmisis);
            return response;
        }
    }
}