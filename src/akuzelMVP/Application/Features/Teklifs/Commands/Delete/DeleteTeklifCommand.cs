using Application.Features.Teklifs.Constants;
using Application.Features.Teklifs.Constants;
using Application.Features.Teklifs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Teklifs.Constants.TeklifsOperationClaims;

namespace Application.Features.Teklifs.Commands.Delete;

public class DeleteTeklifCommand : IRequest<DeletedTeklifResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, TeklifsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTeklifs"];

    public class DeleteTeklifCommandHandler : IRequestHandler<DeleteTeklifCommand, DeletedTeklifResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITeklifRepository _teklifRepository;
        private readonly TeklifBusinessRules _teklifBusinessRules;

        public DeleteTeklifCommandHandler(IMapper mapper, ITeklifRepository teklifRepository,
                                         TeklifBusinessRules teklifBusinessRules)
        {
            _mapper = mapper;
            _teklifRepository = teklifRepository;
            _teklifBusinessRules = teklifBusinessRules;
        }

        public async Task<DeletedTeklifResponse> Handle(DeleteTeklifCommand request, CancellationToken cancellationToken)
        {
            Teklif? teklif = await _teklifRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _teklifBusinessRules.TeklifShouldExistWhenSelected(teklif);

            await _teklifRepository.DeleteAsync(teklif!);

            DeletedTeklifResponse response = _mapper.Map<DeletedTeklifResponse>(teklif);
            return response;
        }
    }
}