using Application.Features.Degerlendirmes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Degerlendirmes.Constants.DegerlendirmesOperationClaims;

namespace Application.Features.Degerlendirmes.Queries.GetList;

public class GetListDegerlendirmeQuery : IRequest<GetListResponse<GetListDegerlendirmeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListDegerlendirmes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetDegerlendirmes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListDegerlendirmeQueryHandler : IRequestHandler<GetListDegerlendirmeQuery, GetListResponse<GetListDegerlendirmeListItemDto>>
    {
        private readonly IDegerlendirmeRepository _degerlendirmeRepository;
        private readonly IMapper _mapper;

        public GetListDegerlendirmeQueryHandler(IDegerlendirmeRepository degerlendirmeRepository, IMapper mapper)
        {
            _degerlendirmeRepository = degerlendirmeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDegerlendirmeListItemDto>> Handle(GetListDegerlendirmeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Degerlendirme> degerlendirmes = await _degerlendirmeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDegerlendirmeListItemDto> response = _mapper.Map<GetListResponse<GetListDegerlendirmeListItemDto>>(degerlendirmes);
            return response;
        }
    }
}