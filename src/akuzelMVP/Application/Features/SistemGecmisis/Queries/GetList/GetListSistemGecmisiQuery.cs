using Application.Features.SistemGecmisis.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.SistemGecmisis.Constants.SistemGecmisisOperationClaims;

namespace Application.Features.SistemGecmisis.Queries.GetList;

public class GetListSistemGecmisiQuery : IRequest<GetListResponse<GetListSistemGecmisiListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListSistemGecmisis({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSistemGecmisis";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSistemGecmisiQueryHandler : IRequestHandler<GetListSistemGecmisiQuery, GetListResponse<GetListSistemGecmisiListItemDto>>
    {
        private readonly ISistemGecmisiRepository _sistemGecmisiRepository;
        private readonly IMapper _mapper;

        public GetListSistemGecmisiQueryHandler(ISistemGecmisiRepository sistemGecmisiRepository, IMapper mapper)
        {
            _sistemGecmisiRepository = sistemGecmisiRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSistemGecmisiListItemDto>> Handle(GetListSistemGecmisiQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SistemGecmisi> sistemGecmisis = await _sistemGecmisiRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSistemGecmisiListItemDto> response = _mapper.Map<GetListResponse<GetListSistemGecmisiListItemDto>>(sistemGecmisis);
            return response;
        }
    }
}