using Application.Features.Ilans.Constants;
using Application.Features.Ilans.Constants;
using Application.Features.Ilans.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Ilans.Constants.IlansOperationClaims;

namespace Application.Features.Ilans.Commands.Delete;

public class DeleteIlanCommand : IRequest<DeletedIlanResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, IlansOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetIlans"];

    public class DeleteIlanCommandHandler : IRequestHandler<DeleteIlanCommand, DeletedIlanResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIlanRepository _ilanRepository;
        private readonly IlanBusinessRules _ilanBusinessRules;

        public DeleteIlanCommandHandler(IMapper mapper, IIlanRepository ilanRepository,
                                         IlanBusinessRules ilanBusinessRules)
        {
            _mapper = mapper;
            _ilanRepository = ilanRepository;
            _ilanBusinessRules = ilanBusinessRules;
        }

        public async Task<DeletedIlanResponse> Handle(DeleteIlanCommand request, CancellationToken cancellationToken)
        {
            Ilan? ilan = await _ilanRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _ilanBusinessRules.IlanShouldExistWhenSelected(ilan);

            await _ilanRepository.DeleteAsync(ilan!);

            DeletedIlanResponse response = _mapper.Map<DeletedIlanResponse>(ilan);
            return response;
        }
    }
}