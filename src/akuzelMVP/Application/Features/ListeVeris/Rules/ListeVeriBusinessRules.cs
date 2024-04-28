using Application.Features.ListeVeris.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ListeVeris.Rules;

public class ListeVeriBusinessRules : BaseBusinessRules
{
    private readonly IListeVeriRepository _listeVeriRepository;
    private readonly ILocalizationService _localizationService;

    public ListeVeriBusinessRules(IListeVeriRepository listeVeriRepository, ILocalizationService localizationService)
    {
        _listeVeriRepository = listeVeriRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ListeVerisBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ListeVeriShouldExistWhenSelected(ListeVeri? listeVeri)
    {
        if (listeVeri == null)
            await throwBusinessException(ListeVerisBusinessMessages.ListeVeriNotExists);
    }

    public async Task ListeVeriIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ListeVeri? listeVeri = await _listeVeriRepository.GetAsync(
            predicate: lv => lv.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ListeVeriShouldExistWhenSelected(listeVeri);
    }
}