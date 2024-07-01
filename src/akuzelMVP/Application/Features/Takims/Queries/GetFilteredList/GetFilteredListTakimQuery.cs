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
using Application.Features.Takims.Queries.GetList;
using System.Linq.Expressions;
using Application.Services.SearchService;

namespace Application.Features.Takims.Queries.GetFilteredList;

public class GetFilteredListTakimQuery : IRequest<GetListResponse<GetFilteredListTakimListItemDto>>/*, ISecuredRequest,*//* ICachableRequest*/
{
    public PageRequest PageRequest { get; set; }

    public GetFilteredListTakimFilterDto Filtreler { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTakims({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTakims";
    public TimeSpan? SlidingExpiration { get; }

    public class GetFilteredListTakimQueryHandler : IRequestHandler<GetFilteredListTakimQuery, GetListResponse<GetFilteredListTakimListItemDto>>
    {
        private readonly ITakimRepository _takimRepository;
        private readonly IMapper _mapper;
        private readonly ISearchService<Takim> _searchService;

        public GetFilteredListTakimQueryHandler(ITakimRepository takimRepository, IMapper mapper, ISearchService<Takim> searchService)
        {
            _takimRepository = takimRepository;
            _mapper = mapper;
            _searchService = searchService;
        }

        public async Task<GetListResponse<GetFilteredListTakimListItemDto>> Handle(GetFilteredListTakimQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Takim, bool>> predicate = a => true;

            if(request.Filtreler.KurucuId != null)
            {
                //var valueStr = request.Filtreler.KurucuId.ToString();
                var newFilter = _searchService.GuidEqual("KurucuId", request.Filtreler.KurucuId.Value);
                predicate = _searchService.AndConcat(predicate, newFilter).ToExpression(null);
            }

            if (request.Filtreler.Adi != null && request.Filtreler.Adi.Length > 0)
            {
                var newFilter = _searchService.StringContains("Adý", request.Filtreler.Adi);
                predicate = _searchService.AndConcat(predicate, newFilter).ToExpression(null);
            }


            //// Compile the predicate for GetFilteredListTakimFilterDto
            //var compiledPredicate = predicate.Compile();

            //// Convert the compiled predicate to work with Takim entities
            //Expression<Func<Takim, bool>> takimPredicate = takim => compiledPredicate(new GetFilteredListTakimFilterDto
            //{
            //    KurucuId = takim.KurucuId,
            //    Adi = takim.Adý,
            //    // ... other properties if needed
            //});


            IPaginate<Takim> takims = await _takimRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken,
                predicate: predicate
            );

            GetListResponse<GetFilteredListTakimListItemDto> response = _mapper.Map<GetListResponse<GetFilteredListTakimListItemDto>>(takims);
            return response;
        }
    }
}