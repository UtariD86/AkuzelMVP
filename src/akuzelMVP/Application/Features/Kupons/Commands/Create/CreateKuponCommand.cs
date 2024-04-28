using Application.Features.Kupons.Constants;
using Application.Features.Kupons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using Domain.Enums;
using static Application.Features.Kupons.Constants.KuponsOperationClaims;

namespace Application.Features.Kupons.Commands.Create;

public class CreateKuponCommand : IRequest<CreatedKuponResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required KuponType KuponType { get; set; }
    public required bool Active { get; set; }
    public required bool Used { get; set; }
    public required Tablolar KuponSahibi { get; set; }
    public Guid? KuponSahibiId { get; set; }
    public required string Adi { get; set; }
    public required string Aciklama { get; set; }
    public required double Indirim { get; set; }
    public required string KuponKodu { get; set; }
    public required DateTime Tarih { get; set; }

    public string[] Roles => [Admin, Write, KuponsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetKupons"];

    public class CreateKuponCommandHandler : IRequestHandler<CreateKuponCommand, CreatedKuponResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKuponRepository _kuponRepository;
        private readonly KuponBusinessRules _kuponBusinessRules;

        public CreateKuponCommandHandler(IMapper mapper, IKuponRepository kuponRepository,
                                         KuponBusinessRules kuponBusinessRules)
        {
            _mapper = mapper;
            _kuponRepository = kuponRepository;
            _kuponBusinessRules = kuponBusinessRules;
        }

        public async Task<CreatedKuponResponse> Handle(CreateKuponCommand request, CancellationToken cancellationToken)
        {
            Kupon kupon = _mapper.Map<Kupon>(request);

            await _kuponRepository.AddAsync(kupon);

            CreatedKuponResponse response = _mapper.Map<CreatedKuponResponse>(kupon);
            return response;
        }
    }
}