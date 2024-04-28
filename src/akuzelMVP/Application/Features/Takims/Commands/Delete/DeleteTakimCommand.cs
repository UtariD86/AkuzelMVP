using Application.Features.Takims.Constants;
using Application.Features.Takims.Constants;
using Application.Features.Takims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Takims.Constants.TakimsOperationClaims;

namespace Application.Features.Takims.Commands.Delete;

public class DeleteTakimCommand : IRequest<DeletedTakimResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, TakimsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTakims"];

    public class DeleteTakimCommandHandler : IRequestHandler<DeleteTakimCommand, DeletedTakimResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITakimRepository _takimRepository;
        private readonly TakimBusinessRules _takimBusinessRules;

        public DeleteTakimCommandHandler(IMapper mapper, ITakimRepository takimRepository,
                                         TakimBusinessRules takimBusinessRules)
        {
            _mapper = mapper;
            _takimRepository = takimRepository;
            _takimBusinessRules = takimBusinessRules;
        }

        public async Task<DeletedTakimResponse> Handle(DeleteTakimCommand request, CancellationToken cancellationToken)
        {
            Takim? takim = await _takimRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _takimBusinessRules.TakimShouldExistWhenSelected(takim);

            await _takimRepository.DeleteAsync(takim!);

            DeletedTakimResponse response = _mapper.Map<DeletedTakimResponse>(takim);
            return response;
        }
    }
}