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

namespace Application.Features.Takims.Commands.Create;

public class CreateTakimCommand : IRequest<CreatedTakimResponse>, /*ISecuredRequest,*/ ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid KurucuId { get; set; }
    public required string Adı { get; set; }
    public required double Cuzdan { get; set; }
    public required Guid DuzenleyenId { get; set; }

    public string[] Roles => [Admin, Write, TakimsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTakims"];

    public class CreateTakimCommandHandler : IRequestHandler<CreateTakimCommand, CreatedTakimResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITakimRepository _takimRepository;
        private readonly TakimBusinessRules _takimBusinessRules;

        public CreateTakimCommandHandler(IMapper mapper, ITakimRepository takimRepository,
                                         TakimBusinessRules takimBusinessRules)
        {
            _mapper = mapper;
            _takimRepository = takimRepository;
            _takimBusinessRules = takimBusinessRules;
        }

        public async Task<CreatedTakimResponse> Handle(CreateTakimCommand request, CancellationToken cancellationToken)
        {
            Takim takim = _mapper.Map<Takim>(request);

            await _takimRepository.AddAsync(takim);

            CreatedTakimResponse response = _mapper.Map<CreatedTakimResponse>(takim);
            return response;
        }
    }
}