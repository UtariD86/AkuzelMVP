using Application.Features.Listes.Constants;
using Application.Features.Listes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Listes.Constants.ListesOperationClaims;

namespace Application.Features.Listes.Queries.GetById;

public class GetByIdListeQuery : IRequest<GetByIdListeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdListeQueryHandler : IRequestHandler<GetByIdListeQuery, GetByIdListeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IListeRepository _listeRepository;
        private readonly ListeBusinessRules _listeBusinessRules;

        public GetByIdListeQueryHandler(IMapper mapper, IListeRepository listeRepository, ListeBusinessRules listeBusinessRules)
        {
            _mapper = mapper;
            _listeRepository = listeRepository;
            _listeBusinessRules = listeBusinessRules;
        }

        public async Task<GetByIdListeResponse> Handle(GetByIdListeQuery request, CancellationToken cancellationToken)
        {
            Liste? liste = await _listeRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _listeBusinessRules.ListeShouldExistWhenSelected(liste);

            GetByIdListeResponse response = _mapper.Map<GetByIdListeResponse>(liste);
            return response;
        }
    }
}