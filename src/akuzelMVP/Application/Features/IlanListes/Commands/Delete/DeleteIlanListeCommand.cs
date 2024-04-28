using Application.Features.IlanListes.Constants;
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

namespace Application.Features.IlanListes.Commands.Delete;

public class DeleteIlanListeCommand : IRequest<DeletedIlanListeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, IlanListesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetIlanListes"];

    public class DeleteIlanListeCommandHandler : IRequestHandler<DeleteIlanListeCommand, DeletedIlanListeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIlanListeRepository _ilanListeRepository;
        private readonly IlanListeBusinessRules _ilanListeBusinessRules;

        public DeleteIlanListeCommandHandler(IMapper mapper, IIlanListeRepository ilanListeRepository,
                                         IlanListeBusinessRules ilanListeBusinessRules)
        {
            _mapper = mapper;
            _ilanListeRepository = ilanListeRepository;
            _ilanListeBusinessRules = ilanListeBusinessRules;
        }

        public async Task<DeletedIlanListeResponse> Handle(DeleteIlanListeCommand request, CancellationToken cancellationToken)
        {
            IlanListe? ilanListe = await _ilanListeRepository.GetAsync(predicate: il => il.Id == request.Id, cancellationToken: cancellationToken);
            await _ilanListeBusinessRules.IlanListeShouldExistWhenSelected(ilanListe);

            await _ilanListeRepository.DeleteAsync(ilanListe!);

            DeletedIlanListeResponse response = _mapper.Map<DeletedIlanListeResponse>(ilanListe);
            return response;
        }
    }
}