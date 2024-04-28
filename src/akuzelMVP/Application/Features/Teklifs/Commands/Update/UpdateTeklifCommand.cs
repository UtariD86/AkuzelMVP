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

namespace Application.Features.Teklifs.Commands.Update;

public class UpdateTeklifCommand : IRequest<UpdatedTeklifResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid GonderenId { get; set; }
    public required Guid MuhattapId { get; set; }
    public Guid? IlanId { get; set; }
    public required string Mesaj { get; set; }
    public required double Fiyat { get; set; }
    public required TimeSpan Sure { get; set; }
    public required TeklifStatus Status { get; set; }

    public string[] Roles => [Admin, Write, TeklifsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTeklifs"];

    public class UpdateTeklifCommandHandler : IRequestHandler<UpdateTeklifCommand, UpdatedTeklifResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITeklifRepository _teklifRepository;
        private readonly TeklifBusinessRules _teklifBusinessRules;

        public UpdateTeklifCommandHandler(IMapper mapper, ITeklifRepository teklifRepository,
                                         TeklifBusinessRules teklifBusinessRules)
        {
            _mapper = mapper;
            _teklifRepository = teklifRepository;
            _teklifBusinessRules = teklifBusinessRules;
        }

        public async Task<UpdatedTeklifResponse> Handle(UpdateTeklifCommand request, CancellationToken cancellationToken)
        {
            Teklif? teklif = await _teklifRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _teklifBusinessRules.TeklifShouldExistWhenSelected(teklif);
            teklif = _mapper.Map(request, teklif);

            await _teklifRepository.UpdateAsync(teklif!);

            UpdatedTeklifResponse response = _mapper.Map<UpdatedTeklifResponse>(teklif);
            return response;
        }
    }
}