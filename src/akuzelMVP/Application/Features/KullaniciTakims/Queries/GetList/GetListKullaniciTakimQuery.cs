using Application.Features.KullaniciTakims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.KullaniciTakims.Constants.KullaniciTakimsOperationClaims;

namespace Application.Features.KullaniciTakims.Queries.GetList;

public class GetListKullaniciTakimQuery : IRequest<GetListResponse<GetListKullaniciTakimListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListKullaniciTakims({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetKullaniciTakims";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListKullaniciTakimQueryHandler : IRequestHandler<GetListKullaniciTakimQuery, GetListResponse<GetListKullaniciTakimListItemDto>>
    {
        private readonly IKullaniciTakimRepository _kullaniciTakimRepository;
        private readonly IMapper _mapper;

        public GetListKullaniciTakimQueryHandler(IKullaniciTakimRepository kullaniciTakimRepository, IMapper mapper)
        {
            _kullaniciTakimRepository = kullaniciTakimRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListKullaniciTakimListItemDto>> Handle(GetListKullaniciTakimQuery request, CancellationToken cancellationToken)
        {
            IPaginate<KullaniciTakim> kullaniciTakims = await _kullaniciTakimRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListKullaniciTakimListItemDto> response = _mapper.Map<GetListResponse<GetListKullaniciTakimListItemDto>>(kullaniciTakims);
            return response;
        }
    }
}