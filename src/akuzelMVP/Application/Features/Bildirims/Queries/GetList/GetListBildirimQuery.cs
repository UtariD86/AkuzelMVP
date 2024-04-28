using Application.Features.Bildirims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Bildirims.Constants.BildirimsOperationClaims;

namespace Application.Features.Bildirims.Queries.GetList;

public class GetListBildirimQuery : IRequest<GetListResponse<GetListBildirimListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBildirims({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBildirims";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBildirimQueryHandler : IRequestHandler<GetListBildirimQuery, GetListResponse<GetListBildirimListItemDto>>
    {
        private readonly IBildirimRepository _bildirimRepository;
        private readonly IMapper _mapper;

        public GetListBildirimQueryHandler(IBildirimRepository bildirimRepository, IMapper mapper)
        {
            _bildirimRepository = bildirimRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBildirimListItemDto>> Handle(GetListBildirimQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Bildirim> bildirims = await _bildirimRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBildirimListItemDto> response = _mapper.Map<GetListResponse<GetListBildirimListItemDto>>(bildirims);
            return response;
        }
    }
}