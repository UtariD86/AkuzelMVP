using Application.Features.KullaniciTakims.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.KullaniciTakims.Rules;

public class KullaniciTakimBusinessRules : BaseBusinessRules
{
    private readonly IKullaniciTakimRepository _kullaniciTakimRepository;
    private readonly ILocalizationService _localizationService;

    public KullaniciTakimBusinessRules(IKullaniciTakimRepository kullaniciTakimRepository, ILocalizationService localizationService)
    {
        _kullaniciTakimRepository = kullaniciTakimRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, KullaniciTakimsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task KullaniciTakimShouldExistWhenSelected(KullaniciTakim? kullaniciTakim)
    {
        if (kullaniciTakim == null)
            await throwBusinessException(KullaniciTakimsBusinessMessages.KullaniciTakimNotExists);
    }

    public async Task KullaniciTakimIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        KullaniciTakim? kullaniciTakim = await _kullaniciTakimRepository.GetAsync(
            predicate: kt => kt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await KullaniciTakimShouldExistWhenSelected(kullaniciTakim);
    }
}