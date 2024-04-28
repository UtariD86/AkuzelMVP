using Application.Features.BankaHesaps.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BankaHesaps.Rules;

public class BankaHesapBusinessRules : BaseBusinessRules
{
    private readonly IBankaHesapRepository _bankaHesapRepository;
    private readonly ILocalizationService _localizationService;

    public BankaHesapBusinessRules(IBankaHesapRepository bankaHesapRepository, ILocalizationService localizationService)
    {
        _bankaHesapRepository = bankaHesapRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BankaHesapsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BankaHesapShouldExistWhenSelected(BankaHesap? bankaHesap)
    {
        if (bankaHesap == null)
            await throwBusinessException(BankaHesapsBusinessMessages.BankaHesapNotExists);
    }

    public async Task BankaHesapIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BankaHesap? bankaHesap = await _bankaHesapRepository.GetAsync(
            predicate: bh => bh.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BankaHesapShouldExistWhenSelected(bankaHesap);
    }
}