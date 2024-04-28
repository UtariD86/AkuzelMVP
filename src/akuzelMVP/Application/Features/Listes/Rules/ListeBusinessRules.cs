using Application.Features.Listes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Listes.Rules;

public class ListeBusinessRules : BaseBusinessRules
{
    private readonly IListeRepository _listeRepository;
    private readonly ILocalizationService _localizationService;

    public ListeBusinessRules(IListeRepository listeRepository, ILocalizationService localizationService)
    {
        _listeRepository = listeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ListesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ListeShouldExistWhenSelected(Liste? liste)
    {
        if (liste == null)
            await throwBusinessException(ListesBusinessMessages.ListeNotExists);
    }

    public async Task ListeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Liste? liste = await _listeRepository.GetAsync(
            predicate: l => l.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ListeShouldExistWhenSelected(liste);
    }
}