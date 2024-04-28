using Application.Features.Portfolyoes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Portfolyoes.Constants.PortfolyoesOperationClaims;

namespace Application.Features.Portfolyoes.Queries.GetList;

public class GetListPortfolyoQuery : IRequest<GetListResponse<GetListPortfolyoListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListPortfolyoes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetPortfolyoes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPortfolyoQueryHandler : IRequestHandler<GetListPortfolyoQuery, GetListResponse<GetListPortfolyoListItemDto>>
    {
        private readonly IPortfolyoRepository _portfolyoRepository;
        private readonly IMapper _mapper;

        public GetListPortfolyoQueryHandler(IPortfolyoRepository portfolyoRepository, IMapper mapper)
        {
            _portfolyoRepository = portfolyoRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPortfolyoListItemDto>> Handle(GetListPortfolyoQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Portfolyo> portfolyoes = await _portfolyoRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPortfolyoListItemDto> response = _mapper.Map<GetListResponse<GetListPortfolyoListItemDto>>(portfolyoes);
            return response;
        }
    }
}