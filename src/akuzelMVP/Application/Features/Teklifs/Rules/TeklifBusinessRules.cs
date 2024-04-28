using Application.Features.Teklifs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Teklifs.Rules;

public class TeklifBusinessRules : BaseBusinessRules
{
    private readonly ITeklifRepository _teklifRepository;
    private readonly ILocalizationService _localizationService;

    public TeklifBusinessRules(ITeklifRepository teklifRepository, ILocalizationService localizationService)
    {
        _teklifRepository = teklifRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TeklifsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TeklifShouldExistWhenSelected(Teklif? teklif)
    {
        if (teklif == null)
            await throwBusinessException(TeklifsBusinessMessages.TeklifNotExists);
    }

    public async Task TeklifIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Teklif? teklif = await _teklifRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TeklifShouldExistWhenSelected(teklif);
    }
}