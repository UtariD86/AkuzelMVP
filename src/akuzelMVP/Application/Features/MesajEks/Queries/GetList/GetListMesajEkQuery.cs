using Application.Features.MesajEks.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MesajEks.Constants.MesajEksOperationClaims;

namespace Application.Features.MesajEks.Queries.GetList;

public class GetListMesajEkQuery : IRequest<GetListResponse<GetListMesajEkListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMesajEks({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMesajEks";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMesajEkQueryHandler : IRequestHandler<GetListMesajEkQuery, GetListResponse<GetListMesajEkListItemDto>>
    {
        private readonly IMesajEkRepository _mesajEkRepository;
        private readonly IMapper _mapper;

        public GetListMesajEkQueryHandler(IMesajEkRepository mesajEkRepository, IMapper mapper)
        {
            _mesajEkRepository = mesajEkRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMesajEkListItemDto>> Handle(GetListMesajEkQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MesajEk> mesajEks = await _mesajEkRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMesajEkListItemDto> response = _mapper.Map<GetListResponse<GetListMesajEkListItemDto>>(mesajEks);
            return response;
        }
    }
}