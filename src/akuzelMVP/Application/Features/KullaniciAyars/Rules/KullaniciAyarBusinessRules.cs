using Application.Features.KullaniciAyars.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.KullaniciAyars.Rules;

public class KullaniciAyarBusinessRules : BaseBusinessRules
{
    private readonly IKullaniciAyarRepository _kullaniciAyarRepository;
    private readonly ILocalizationService _localizationService;

    public KullaniciAyarBusinessRules(IKullaniciAyarRepository kullaniciAyarRepository, ILocalizationService localizationService)
    {
        _kullaniciAyarRepository = kullaniciAyarRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, KullaniciAyarsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task KullaniciAyarShouldExistWhenSelected(KullaniciAyar? kullaniciAyar)
    {
        if (kullaniciAyar == null)
            await throwBusinessException(KullaniciAyarsBusinessMessages.KullaniciAyarNotExists);
    }

    public async Task KullaniciAyarIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        KullaniciAyar? kullaniciAyar = await _kullaniciAyarRepository.GetAsync(
            predicate: ka => ka.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await KullaniciAyarShouldExistWhenSelected(kullaniciAyar);
    }
}