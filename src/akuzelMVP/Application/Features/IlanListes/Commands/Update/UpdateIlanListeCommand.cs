using Application.Features.IlanListes.Constants;
using Application.Features.IlanListes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.IlanListes.Constants.IlanListesOperationClaims;

namespace Application.Features.IlanListes.Commands.Update;

public class UpdateIlanListeCommand : IRequest<UpdatedIlanListeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid ListeId { get; set; }
    public required Guid IlanId { get; set; }

    public string[] Roles => [Admin, Write, IlanListesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetIlanListes"];

    public class UpdateIlanListeCommandHandler : IRequestHandler<UpdateIlanListeCommand, UpdatedIlanListeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIlanListeRepository _ilanListeRepository;
        private readonly IlanListeBusinessRules _ilanListeBusinessRules;

        public UpdateIlanListeCommandHandler(IMapper mapper, IIlanListeRepository ilanListeRepository,
                                         IlanListeBusinessRules ilanListeBusinessRules)
        {
            _mapper = mapper;
            _ilanListeRepository = ilanListeRepository;
            _ilanListeBusinessRules = ilanListeBusinessRules;
        }

        public async Task<UpdatedIlanListeResponse> Handle(UpdateIlanListeCommand request, CancellationToken cancellationToken)
        {
            IlanListe? ilanListe = await _ilanListeRepository.GetAsync(predicate: il => il.Id == request.Id, cancellationToken: cancellationToken);
            await _ilanListeBusinessRules.IlanListeShouldExistWhenSelected(ilanListe);
            ilanListe = _mapper.Map(request, ilanListe);

            await _ilanListeRepository.UpdateAsync(ilanListe!);

            UpdatedIlanListeResponse response = _mapper.Map<UpdatedIlanListeResponse>(ilanListe);
            return response;
        }
    }
}