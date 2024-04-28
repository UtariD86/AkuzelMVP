using Application.Features.Kupons.Constants;
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
using static Application.Features.Kupons.Constants.KuponsOperationClaims;

namespace Application.Features.Kupons.Commands.Delete;

public class DeleteKuponCommand : IRequest<DeletedKuponResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, KuponsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetKupons"];

    public class DeleteKuponCommandHandler : IRequestHandler<DeleteKuponCommand, DeletedKuponResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKuponRepository _kuponRepository;
        private readonly KuponBusinessRules _kuponBusinessRules;

        public DeleteKuponCommandHandler(IMapper mapper, IKuponRepository kuponRepository,
                                         KuponBusinessRules kuponBusinessRules)
        {
            _mapper = mapper;
            _kuponRepository = kuponRepository;
            _kuponBusinessRules = kuponBusinessRules;
        }

        public async Task<DeletedKuponResponse> Handle(DeleteKuponCommand request, CancellationToken cancellationToken)
        {
            Kupon? kupon = await _kuponRepository.GetAsync(predicate: k => k.Id == request.Id, cancellationToken: cancellationToken);
            await _kuponBusinessRules.KuponShouldExistWhenSelected(kupon);

            await _kuponRepository.DeleteAsync(kupon!);

            DeletedKuponResponse response = _mapper.Map<DeletedKuponResponse>(kupon);
            return response;
        }
    }
}