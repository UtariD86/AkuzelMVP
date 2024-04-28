using Application.Features.Siparis.Constants;
using Application.Features.Siparis.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Siparis.Constants.SiparisOperationClaims;

namespace Application.Features.Siparis.Queries.GetById;

public class GetByIdSiparisQuery : IRequest<GetByIdSiparisResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdSiparisQueryHandler : IRequestHandler<GetByIdSiparisQuery, GetByIdSiparisResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISiparisRepository _siparisRepository;
        private readonly SiparisBusinessRules _siparisBusinessRules;

        public GetByIdSiparisQueryHandler(IMapper mapper, ISiparisRepository siparisRepository, SiparisBusinessRules siparisBusinessRules)
        {
            _mapper = mapper;
            _siparisRepository = siparisRepository;
            _siparisBusinessRules = siparisBusinessRules;
        }

        public async Task<GetByIdSiparisResponse> Handle(GetByIdSiparisQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Siparis? siparis = await _siparisRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _siparisBusinessRules.SiparisShouldExistWhenSelected(siparis);

            GetByIdSiparisResponse response = _mapper.Map<GetByIdSiparisResponse>(siparis);
            return response;
        }
    }
}