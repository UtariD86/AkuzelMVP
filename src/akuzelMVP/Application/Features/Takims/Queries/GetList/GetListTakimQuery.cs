using Application.Features.Takims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Takims.Constants.TakimsOperationClaims;

namespace Application.Features.Takims.Queries.GetList;

public class GetListTakimQuery : IRequest<GetListResponse<GetListTakimListItemDto>>, /*ISecuredRequest,*/ ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTakims({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTakims";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTakimQueryHandler : IRequestHandler<GetListTakimQuery, GetListResponse<GetListTakimListItemDto>>
    {
        private readonly ITakimRepository _takimRepository;
        private readonly IMapper _mapper;

        public GetListTakimQueryHandler(ITakimRepository takimRepository, IMapper mapper)
        {
            _takimRepository = takimRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTakimListItemDto>> Handle(GetListTakimQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Takim> takims = await _takimRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTakimListItemDto> response = _mapper.Map<GetListResponse<GetListTakimListItemDto>>(takims);
            return response;
        }
    }
}