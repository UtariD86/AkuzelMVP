using Application.Features.Takims.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Takims.Rules;

public class TakimBusinessRules : BaseBusinessRules
{
    private readonly ITakimRepository _takimRepository;
    private readonly ILocalizationService _localizationService;

    public TakimBusinessRules(ITakimRepository takimRepository, ILocalizationService localizationService)
    {
        _takimRepository = takimRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TakimsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TakimShouldExistWhenSelected(Takim? takim)
    {
        if (takim == null)
            await throwBusinessException(TakimsBusinessMessages.TakimNotExists);
    }

    public async Task TakimIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Takim? takim = await _takimRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TakimShouldExistWhenSelected(takim);
    }
}