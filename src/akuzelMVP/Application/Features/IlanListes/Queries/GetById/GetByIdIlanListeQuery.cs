using Application.Features.IlanListes.Constants;
using Application.Features.IlanListes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.IlanListes.Constants.IlanListesOperationClaims;

namespace Application.Features.IlanListes.Queries.GetById;

public class GetByIdIlanListeQuery : IRequest<GetByIdIlanListeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdIlanListeQueryHandler : IRequestHandler<GetByIdIlanListeQuery, GetByIdIlanListeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIlanListeRepository _ilanListeRepository;
        private readonly IlanListeBusinessRules _ilanListeBusinessRules;

        public GetByIdIlanListeQueryHandler(IMapper mapper, IIlanListeRepository ilanListeRepository, IlanListeBusinessRules ilanListeBusinessRules)
        {
            _mapper = mapper;
            _ilanListeRepository = ilanListeRepository;
            _ilanListeBusinessRules = ilanListeBusinessRules;
        }

        public async Task<GetByIdIlanListeResponse> Handle(GetByIdIlanListeQuery request, CancellationToken cancellationToken)
        {
            IlanListe? ilanListe = await _ilanListeRepository.GetAsync(predicate: il => il.Id == request.Id, cancellationToken: cancellationToken);
            await _ilanListeBusinessRules.IlanListeShouldExistWhenSelected(ilanListe);

            GetByIdIlanListeResponse response = _mapper.Map<GetByIdIlanListeResponse>(ilanListe);
            return response;
        }
    }
}