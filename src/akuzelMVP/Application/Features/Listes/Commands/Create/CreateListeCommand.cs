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

namespace Application.Features.Listes.Commands.Create;

public class CreateListeCommand : IRequest<CreatedListeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid KullaniciId { get; set; }
    public required ListeType Type { get; set; }
    public required string Adı { get; set; }

    public string[] Roles => [Admin, Write, ListesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetListes"];

    public class CreateListeCommandHandler : IRequestHandler<CreateListeCommand, CreatedListeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IListeRepository _listeRepository;
        private readonly ListeBusinessRules _listeBusinessRules;

        public CreateListeCommandHandler(IMapper mapper, IListeRepository listeRepository,
                                         ListeBusinessRules listeBusinessRules)
        {
            _mapper = mapper;
            _listeRepository = listeRepository;
            _listeBusinessRules = listeBusinessRules;
        }

        public async Task<CreatedListeResponse> Handle(CreateListeCommand request, CancellationToken cancellationToken)
        {
            Liste liste = _mapper.Map<Liste>(request);

            await _listeRepository.AddAsync(liste);

            CreatedListeResponse response = _mapper.Map<CreatedListeResponse>(liste);
            return response;
        }
    }
}