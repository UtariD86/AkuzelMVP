using Application.Features.Listes.Constants;
using Application.Features.Listes.Constants;
using Application.Features.Listes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Listes.Constants.ListesOperationClaims;

namespace Application.Features.Listes.Commands.Delete;

public class DeleteListeCommand : IRequest<DeletedListeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ListesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetListes"];

    public class DeleteListeCommandHandler : IRequestHandler<DeleteListeCommand, DeletedListeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IListeRepository _listeRepository;
        private readonly ListeBusinessRules _listeBusinessRules;

        public DeleteListeCommandHandler(IMapper mapper, IListeRepository listeRepository,
                                         ListeBusinessRules listeBusinessRules)
        {
            _mapper = mapper;
            _listeRepository = listeRepository;
            _listeBusinessRules = listeBusinessRules;
        }

        public async Task<DeletedListeResponse> Handle(DeleteListeCommand request, CancellationToken cancellationToken)
        {
            Liste? liste = await _listeRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _listeBusinessRules.ListeShouldExistWhenSelected(liste);

            await _listeRepository.DeleteAsync(liste!);

            DeletedListeResponse response = _mapper.Map<DeletedListeResponse>(liste);
            return response;
        }
    }
}