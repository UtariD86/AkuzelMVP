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

namespace Application.Features.Kupons.Commands.Update;

public class UpdateKuponCommand : IRequest<UpdatedKuponResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
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

    public string[] Roles => [Admin, Write, KuponsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetKupons"];

    public class UpdateKuponCommandHandler : IRequestHandler<UpdateKuponCommand, UpdatedKuponResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKuponRepository _kuponRepository;
        private readonly KuponBusinessRules _kuponBusinessRules;

        public UpdateKuponCommandHandler(IMapper mapper, IKuponRepository kuponRepository,
                                         KuponBusinessRules kuponBusinessRules)
        {
            _mapper = mapper;
            _kuponRepository = kuponRepository;
            _kuponBusinessRules = kuponBusinessRules;
        }

        public async Task<UpdatedKuponResponse> Handle(UpdateKuponCommand request, CancellationToken cancellationToken)
        {
            Kupon? kupon = await _kuponRepository.GetAsync(predicate: k => k.Id == request.Id, cancellationToken: cancellationToken);
            await _kuponBusinessRules.KuponShouldExistWhenSelected(kupon);
            kupon = _mapper.Map(request, kupon);

            await _kuponRepository.UpdateAsync(kupon!);

            UpdatedKuponResponse response = _mapper.Map<UpdatedKuponResponse>(kupon);
            return response;
        }
    }
}