using Application.Features.Ilans.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Ilans.Rules;

public class IlanBusinessRules : BaseBusinessRules
{
    private readonly IIlanRepository _ilanRepository;
    private readonly ILocalizationService _localizationService;

    public IlanBusinessRules(IIlanRepository ilanRepository, ILocalizationService localizationService)
    {
        _ilanRepository = ilanRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, IlansBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task IlanShouldExistWhenSelected(Ilan? ilan)
    {
        if (ilan == null)
            await throwBusinessException(IlansBusinessMessages.IlanNotExists);
    }

    public async Task IlanIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Ilan? ilan = await _ilanRepository.GetAsync(
            predicate: i => i.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await IlanShouldExistWhenSelected(ilan);
    }
}