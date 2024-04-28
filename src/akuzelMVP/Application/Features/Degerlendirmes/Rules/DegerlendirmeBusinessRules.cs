using Application.Features.Degerlendirmes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Degerlendirmes.Rules;

public class DegerlendirmeBusinessRules : BaseBusinessRules
{
    private readonly IDegerlendirmeRepository _degerlendirmeRepository;
    private readonly ILocalizationService _localizationService;

    public DegerlendirmeBusinessRules(IDegerlendirmeRepository degerlendirmeRepository, ILocalizationService localizationService)
    {
        _degerlendirmeRepository = degerlendirmeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DegerlendirmesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DegerlendirmeShouldExistWhenSelected(Degerlendirme? degerlendirme)
    {
        if (degerlendirme == null)
            await throwBusinessException(DegerlendirmesBusinessMessages.DegerlendirmeNotExists);
    }

    public async Task DegerlendirmeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Degerlendirme? degerlendirme = await _degerlendirmeRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DegerlendirmeShouldExistWhenSelected(degerlendirme);
    }
}