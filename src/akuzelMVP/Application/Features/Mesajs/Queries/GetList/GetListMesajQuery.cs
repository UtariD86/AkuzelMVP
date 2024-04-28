using Application.Features.Mesajs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Mesajs.Constants.MesajsOperationClaims;

namespace Application.Features.Mesajs.Queries.GetList;

public class GetListMesajQuery : IRequest<GetListResponse<GetListMesajListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMesajs({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMesajs";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMesajQueryHandler : IRequestHandler<GetListMesajQuery, GetListResponse<GetListMesajListItemDto>>
    {
        private readonly IMesajRepository _mesajRepository;
        private readonly IMapper _mapper;

        public GetListMesajQueryHandler(IMesajRepository mesajRepository, IMapper mapper)
        {
            _mesajRepository = mesajRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMesajListItemDto>> Handle(GetListMesajQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Mesaj> mesajs = await _mesajRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMesajListItemDto> response = _mapper.Map<GetListResponse<GetListMesajListItemDto>>(mesajs);
            return response;
        }
    }
}