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
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using static Application.Features.Ilans.Constants.IlansOperationClaims;

namespace Application.Features.Ilans.Commands.Create;

public class CreateIlanCommand : IRequest<CreatedIlanResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid KategoriId { get; set; }
    public required IlanSahibiType IlanSahibiType { get; set; }
    public required Guid IlanSahibiId { get; set; }
    public required Guid IlanNo { get; set; }
    public required string Baslik { get; set; }
    public required string Aciklama { get; set; }
    public required IlanOnayStatus Status { get; set; }
    public required double Fiyat { get; set; }
    public required TimeSpan Sure { get; set; }
    public required IlanYayinStatus YayinDurumu { get; set; }

    public string[] Roles => [Admin, Write, IlansOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetIlans"];

    public class CreateIlanCommandHandler : IRequestHandler<CreateIlanCommand, CreatedIlanResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIlanRepository _ilanRepository;
        private readonly IlanBusinessRules _ilanBusinessRules;

        public CreateIlanCommandHandler(IMapper mapper, IIlanRepository ilanRepository,
                                         IlanBusinessRules ilanBusinessRules)
        {
            _mapper = mapper;
            _ilanRepository = ilanRepository;
            _ilanBusinessRules = ilanBusinessRules;
        }

        public async Task<CreatedIlanResponse> Handle(CreateIlanCommand request, CancellationToken cancellationToken)
        {
            Ilan ilan = _mapper.Map<Ilan>(request);

            await _ilanRepository.AddAsync(ilan);

            CreatedIlanResponse response = _mapper.Map<CreatedIlanResponse>(ilan);
            return response;
        }
    }
}