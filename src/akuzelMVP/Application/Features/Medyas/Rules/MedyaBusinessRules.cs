using Application.Features.Medyas.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Medyas.Rules;

public class MedyaBusinessRules : BaseBusinessRules
{
    private readonly IMedyaRepository _medyaRepository;
    private readonly ILocalizationService _localizationService;

    public MedyaBusinessRules(IMedyaRepository medyaRepository, ILocalizationService localizationService)
    {
        _medyaRepository = medyaRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MedyasBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MedyaShouldExistWhenSelected(Medya? medya)
    {
        if (medya == null)
            await throwBusinessException(MedyasBusinessMessages.MedyaNotExists);
    }

    public async Task MedyaIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Medya? medya = await _medyaRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MedyaShouldExistWhenSelected(medya);
    }
}