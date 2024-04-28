using Application.Features.KullaniciAyars.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.KullaniciAyars.Constants.KullaniciAyarsOperationClaims;

namespace Application.Features.KullaniciAyars.Queries.GetList;

public class GetListKullaniciAyarQuery : IRequest<GetListResponse<GetListKullaniciAyarListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListKullaniciAyars({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetKullaniciAyars";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListKullaniciAyarQueryHandler : IRequestHandler<GetListKullaniciAyarQuery, GetListResponse<GetListKullaniciAyarListItemDto>>
    {
        private readonly IKullaniciAyarRepository _kullaniciAyarRepository;
        private readonly IMapper _mapper;

        public GetListKullaniciAyarQueryHandler(IKullaniciAyarRepository kullaniciAyarRepository, IMapper mapper)
        {
            _kullaniciAyarRepository = kullaniciAyarRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListKullaniciAyarListItemDto>> Handle(GetListKullaniciAyarQuery request, CancellationToken cancellationToken)
        {
            IPaginate<KullaniciAyar> kullaniciAyars = await _kullaniciAyarRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListKullaniciAyarListItemDto> response = _mapper.Map<GetListResponse<GetListKullaniciAyarListItemDto>>(kullaniciAyars);
            return response;
        }
    }
}