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

namespace Application.Features.IlanListes.Commands.Create;

public class CreateIlanListeCommand : IRequest<CreatedIlanListeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid ListeId { get; set; }
    public required Guid IlanId { get; set; }

    public string[] Roles => [Admin, Write, IlanListesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetIlanListes"];

    public class CreateIlanListeCommandHandler : IRequestHandler<CreateIlanListeCommand, CreatedIlanListeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIlanListeRepository _ilanListeRepository;
        private readonly IlanListeBusinessRules _ilanListeBusinessRules;

        public CreateIlanListeCommandHandler(IMapper mapper, IIlanListeRepository ilanListeRepository,
                                         IlanListeBusinessRules ilanListeBusinessRules)
        {
            _mapper = mapper;
            _ilanListeRepository = ilanListeRepository;
            _ilanListeBusinessRules = ilanListeBusinessRules;
        }

        public async Task<CreatedIlanListeResponse> Handle(CreateIlanListeCommand request, CancellationToken cancellationToken)
        {
            IlanListe ilanListe = _mapper.Map<IlanListe>(request);

            await _ilanListeRepository.AddAsync(ilanListe);

            CreatedIlanListeResponse response = _mapper.Map<CreatedIlanListeResponse>(ilanListe);
            return response;
        }
    }
}