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

namespace Application.Features.BankaHesaps.Commands.Update;

public class UpdateBankaHesapCommand : IRequest<UpdatedBankaHesapResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required bool TakimMi { get; set; }
    public required Guid SahipId { get; set; }
    public required Banka Banka { get; set; }
    public required string HesapAdı { get; set; }
    public required string Iban { get; set; }
    public required string HesapNo { get; set; }

    public string[] Roles => [Admin, Write, BankaHesapsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBankaHesaps"];

    public class UpdateBankaHesapCommandHandler : IRequestHandler<UpdateBankaHesapCommand, UpdatedBankaHesapResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBankaHesapRepository _bankaHesapRepository;
        private readonly BankaHesapBusinessRules _bankaHesapBusinessRules;

        public UpdateBankaHesapCommandHandler(IMapper mapper, IBankaHesapRepository bankaHesapRepository,
                                         BankaHesapBusinessRules bankaHesapBusinessRules)
        {
            _mapper = mapper;
            _bankaHesapRepository = bankaHesapRepository;
            _bankaHesapBusinessRules = bankaHesapBusinessRules;
        }

        public async Task<UpdatedBankaHesapResponse> Handle(UpdateBankaHesapCommand request, CancellationToken cancellationToken)
        {
            BankaHesap? bankaHesap = await _bankaHesapRepository.GetAsync(predicate: bh => bh.Id == request.Id, cancellationToken: cancellationToken);
            await _bankaHesapBusinessRules.BankaHesapShouldExistWhenSelected(bankaHesap);
            bankaHesap = _mapper.Map(request, bankaHesap);

            await _bankaHesapRepository.UpdateAsync(bankaHesap!);

            UpdatedBankaHesapResponse response = _mapper.Map<UpdatedBankaHesapResponse>(bankaHesap);
            return response;
        }
    }
}