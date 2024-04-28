using Application.Features.BankaHesaps.Constants;
using Application.Features.BankaHesaps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using static Application.Features.BankaHesaps.Constants.BankaHesapsOperationClaims;

namespace Application.Features.BankaHesaps.Commands.Create;

public class CreateBankaHesapCommand : IRequest<CreatedBankaHesapResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required bool TakimMi { get; set; }
    public required Guid SahipId { get; set; }
    public required Banka Banka { get; set; }
    public required string HesapAdı { get; set; }
    public required string Iban { get; set; }
    public required string HesapNo { get; set; }

    public string[] Roles => [Admin, Write, BankaHesapsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBankaHesaps"];

    public class CreateBankaHesapCommandHandler : IRequestHandler<CreateBankaHesapCommand, CreatedBankaHesapResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBankaHesapRepository _bankaHesapRepository;
        private readonly BankaHesapBusinessRules _bankaHesapBusinessRules;

        public CreateBankaHesapCommandHandler(IMapper mapper, IBankaHesapRepository bankaHesapRepository,
                                         BankaHesapBusinessRules bankaHesapBusinessRules)
        {
            _mapper = mapper;
            _bankaHesapRepository = bankaHesapRepository;
            _bankaHesapBusinessRules = bankaHesapBusinessRules;
        }

        public async Task<CreatedBankaHesapResponse> Handle(CreateBankaHesapCommand request, CancellationToken cancellationToken)
        {
            BankaHesap bankaHesap = _mapper.Map<BankaHesap>(request);

            await _bankaHesapRepository.AddAsync(bankaHesap);

            CreatedBankaHesapResponse response = _mapper.Map<CreatedBankaHesapResponse>(bankaHesap);
            return response;
        }
    }
}