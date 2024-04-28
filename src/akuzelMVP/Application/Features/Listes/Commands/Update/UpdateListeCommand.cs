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
using Domain.Enums;
using static Application.Features.Listes.Constants.ListesOperationClaims;

namespace Application.Features.Listes.Commands.Update;

public class UpdateListeCommand : IRequest<UpdatedListeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid KullaniciId { get; set; }
    public required ListeType Type { get; set; }
    public required string Adı { get; set; }

    public string[] Roles => [Admin, Write, ListesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetListes"];

    public class UpdateListeCommandHandler : IRequestHandler<UpdateListeCommand, UpdatedListeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IListeRepository _listeRepository;
        private readonly ListeBusinessRules _listeBusinessRules;

        public UpdateListeCommandHandler(IMapper mapper, IListeRepository listeRepository,
                                         ListeBusinessRules listeBusinessRules)
        {
            _mapper = mapper;
            _listeRepository = listeRepository;
            _listeBusinessRules = listeBusinessRules;
        }

        public async Task<UpdatedListeResponse> Handle(UpdateListeCommand request, CancellationToken cancellationToken)
        {
            Liste? liste = await _listeRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _listeBusinessRules.ListeShouldExistWhenSelected(liste);
            liste = _mapper.Map(request, liste);

            await _listeRepository.UpdateAsync(liste!);

            UpdatedListeResponse response = _mapper.Map<UpdatedListeResponse>(liste);
            return response;
        }
    }
}