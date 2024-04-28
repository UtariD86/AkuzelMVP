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

namespace Application.Features.Takims.Commands.Update;

public class UpdateTakimCommand : IRequest<UpdatedTakimResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid KurucuId { get; set; }
    public required string Adı { get; set; }
    public required double Cuzdan { get; set; }
    public required Guid DuzenleyenId { get; set; }

    public string[] Roles => [Admin, Write, TakimsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTakims"];

    public class UpdateTakimCommandHandler : IRequestHandler<UpdateTakimCommand, UpdatedTakimResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITakimRepository _takimRepository;
        private readonly TakimBusinessRules _takimBusinessRules;

        public UpdateTakimCommandHandler(IMapper mapper, ITakimRepository takimRepository,
                                         TakimBusinessRules takimBusinessRules)
        {
            _mapper = mapper;
            _takimRepository = takimRepository;
            _takimBusinessRules = takimBusinessRules;
        }

        public async Task<UpdatedTakimResponse> Handle(UpdateTakimCommand request, CancellationToken cancellationToken)
        {
            Takim? takim = await _takimRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _takimBusinessRules.TakimShouldExistWhenSelected(takim);
            takim = _mapper.Map(request, takim);

            await _takimRepository.UpdateAsync(takim!);

            UpdatedTakimResponse response = _mapper.Map<UpdatedTakimResponse>(takim);
            return response;
        }
    }
}