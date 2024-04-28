using Application.Features.Teklifs.Constants;
using Application.Features.Teklifs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Teklifs.Constants.TeklifsOperationClaims;

namespace Application.Features.Teklifs.Queries.GetById;

public class GetByIdTeklifQuery : IRequest<GetByIdTeklifResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTeklifQueryHandler : IRequestHandler<GetByIdTeklifQuery, GetByIdTeklifResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITeklifRepository _teklifRepository;
        private readonly TeklifBusinessRules _teklifBusinessRules;

        public GetByIdTeklifQueryHandler(IMapper mapper, ITeklifRepository teklifRepository, TeklifBusinessRules teklifBusinessRules)
        {
            _mapper = mapper;
            _teklifRepository = teklifRepository;
            _teklifBusinessRules = teklifBusinessRules;
        }

        public async Task<GetByIdTeklifResponse> Handle(GetByIdTeklifQuery request, CancellationToken cancellationToken)
        {
            Teklif? teklif = await _teklifRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _teklifBusinessRules.TeklifShouldExistWhenSelected(teklif);

            GetByIdTeklifResponse response = _mapper.Map<GetByIdTeklifResponse>(teklif);
            return response;
        }
    }
}