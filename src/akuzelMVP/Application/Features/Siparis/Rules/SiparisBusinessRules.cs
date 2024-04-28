using Application.Features.Siparis.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Siparis.Rules;

public class SiparisBusinessRules : BaseBusinessRules
{
    private readonly ISiparisRepository _siparisRepository;
    private readonly ILocalizationService _localizationService;

    public SiparisBusinessRules(ISiparisRepository siparisRepository, ILocalizationService localizationService)
    {
        _siparisRepository = siparisRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SiparisBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SiparisShouldExistWhenSelected(Siparis? siparis)
    {
        if (siparis == null)
            await throwBusinessException(SiparisBusinessMessages.SiparisNotExists);
    }

    public async Task SiparisIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Siparis? siparis = await _siparisRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SiparisShouldExistWhenSelected(siparis);
    }
}