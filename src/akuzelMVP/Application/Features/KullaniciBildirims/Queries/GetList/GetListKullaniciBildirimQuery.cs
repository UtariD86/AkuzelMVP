using Application.Features.KullaniciBildirims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.KullaniciBildirims.Constants.KullaniciBildirimsOperationClaims;

namespace Application.Features.KullaniciBildirims.Queries.GetList;

public class GetListKullaniciBildirimQuery : IRequest<GetListResponse<GetListKullaniciBildirimListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListKullaniciBildirims({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetKullaniciBildirims";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListKullaniciBildirimQueryHandler : IRequestHandler<GetListKullaniciBildirimQuery, GetListResponse<GetListKullaniciBildirimListItemDto>>
    {
        private readonly IKullaniciBildirimRepository _kullaniciBildirimRepository;
        private readonly IMapper _mapper;

        public GetListKullaniciBildirimQueryHandler(IKullaniciBildirimRepository kullaniciBildirimRepository, IMapper mapper)
        {
            _kullaniciBildirimRepository = kullaniciBildirimRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListKullaniciBildirimListItemDto>> Handle(GetListKullaniciBildirimQuery request, CancellationToken cancellationToken)
        {
            IPaginate<KullaniciBildirim> kullaniciBildirims = await _kullaniciBildirimRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListKullaniciBildirimListItemDto> response = _mapper.Map<GetListResponse<GetListKullaniciBildirimListItemDto>>(kullaniciBildirims);
            return response;
        }
    }
}