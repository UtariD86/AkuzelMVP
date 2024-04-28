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
using Domain.Enums;
using static Application.Features.Teklifs.Constants.TeklifsOperationClaims;

namespace Application.Features.Teklifs.Commands.Create;

public class CreateTeklifCommand : IRequest<CreatedTeklifResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid GonderenId { get; set; }
    public required Guid MuhattapId { get; set; }
    public Guid? IlanId { get; set; }
    public required string Mesaj { get; set; }
    public required double Fiyat { get; set; }
    public required TimeSpan Sure { get; set; }
    public required TeklifStatus Status { get; set; }

    public string[] Roles => [Admin, Write, TeklifsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTeklifs"];

    public class CreateTeklifCommandHandler : IRequestHandler<CreateTeklifCommand, CreatedTeklifResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITeklifRepository _teklifRepository;
        private readonly TeklifBusinessRules _teklifBusinessRules;

        public CreateTeklifCommandHandler(IMapper mapper, ITeklifRepository teklifRepository,
                                         TeklifBusinessRules teklifBusinessRules)
        {
            _mapper = mapper;
            _teklifRepository = teklifRepository;
            _teklifBusinessRules = teklifBusinessRules;
        }

        public async Task<CreatedTeklifResponse> Handle(CreateTeklifCommand request, CancellationToken cancellationToken)
        {
            Teklif teklif = _mapper.Map<Teklif>(request);

            await _teklifRepository.AddAsync(teklif);

            CreatedTeklifResponse response = _mapper.Map<CreatedTeklifResponse>(teklif);
            return response;
        }
    }
}