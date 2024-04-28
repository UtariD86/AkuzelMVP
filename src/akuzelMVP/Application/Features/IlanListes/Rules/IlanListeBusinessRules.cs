using Application.Features.IlanListes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.IlanListes.Rules;

public class IlanListeBusinessRules : BaseBusinessRules
{
    private readonly IIlanListeRepository _ilanListeRepository;
    private readonly ILocalizationService _localizationService;

    public IlanListeBusinessRules(IIlanListeRepository ilanListeRepository, ILocalizationService localizationService)
    {
        _ilanListeRepository = ilanListeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, IlanListesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task IlanListeShouldExistWhenSelected(IlanListe? ilanListe)
    {
        if (ilanListe == null)
            await throwBusinessException(IlanListesBusinessMessages.IlanListeNotExists);
    }

    public async Task IlanListeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        IlanListe? ilanListe = await _ilanListeRepository.GetAsync(
            predicate: il => il.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await IlanListeShouldExistWhenSelected(ilanListe);
    }
}