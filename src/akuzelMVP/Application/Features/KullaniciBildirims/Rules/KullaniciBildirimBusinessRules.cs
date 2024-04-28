using Application.Features.KullaniciBildirims.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.KullaniciBildirims.Rules;

public class KullaniciBildirimBusinessRules : BaseBusinessRules
{
    private readonly IKullaniciBildirimRepository _kullaniciBildirimRepository;
    private readonly ILocalizationService _localizationService;

    public KullaniciBildirimBusinessRules(IKullaniciBildirimRepository kullaniciBildirimRepository, ILocalizationService localizationService)
    {
        _kullaniciBildirimRepository = kullaniciBildirimRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, KullaniciBildirimsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task KullaniciBildirimShouldExistWhenSelected(KullaniciBildirim? kullaniciBildirim)
    {
        if (kullaniciBildirim == null)
            await throwBusinessException(KullaniciBildirimsBusinessMessages.KullaniciBildirimNotExists);
    }

    public async Task KullaniciBildirimIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        KullaniciBildirim? kullaniciBildirim = await _kullaniciBildirimRepository.GetAsync(
            predicate: kb => kb.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await KullaniciBildirimShouldExistWhenSelected(kullaniciBildirim);
    }
}