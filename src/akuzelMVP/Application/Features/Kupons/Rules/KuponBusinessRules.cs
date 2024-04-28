using Application.Features.Kupons.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Kupons.Rules;

public class KuponBusinessRules : BaseBusinessRules
{
    private readonly IKuponRepository _kuponRepository;
    private readonly ILocalizationService _localizationService;

    public KuponBusinessRules(IKuponRepository kuponRepository, ILocalizationService localizationService)
    {
        _kuponRepository = kuponRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, KuponsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task KuponShouldExistWhenSelected(Kupon? kupon)
    {
        if (kupon == null)
            await throwBusinessException(KuponsBusinessMessages.KuponNotExists);
    }

    public async Task KuponIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Kupon? kupon = await _kuponRepository.GetAsync(
            predicate: k => k.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await KuponShouldExistWhenSelected(kupon);
    }
}