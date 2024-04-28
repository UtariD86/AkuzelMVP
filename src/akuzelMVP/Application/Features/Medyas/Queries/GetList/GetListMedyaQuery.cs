using Application.Features.Medyas.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Medyas.Constants.MedyasOperationClaims;

namespace Application.Features.Medyas.Queries.GetList;

public class GetListMedyaQuery : IRequest<GetListResponse<GetListMedyaListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMedyas({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMedyas";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMedyaQueryHandler : IRequestHandler<GetListMedyaQuery, GetListResponse<GetListMedyaListItemDto>>
    {
        private readonly IMedyaRepository _medyaRepository;
        private readonly IMapper _mapper;

        public GetListMedyaQueryHandler(IMedyaRepository medyaRepository, IMapper mapper)
        {
            _medyaRepository = medyaRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMedyaListItemDto>> Handle(GetListMedyaQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Medya> medyas = await _medyaRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMedyaListItemDto> response = _mapper.Map<GetListResponse<GetListMedyaListItemDto>>(medyas);
            return response;
        }
    }
}