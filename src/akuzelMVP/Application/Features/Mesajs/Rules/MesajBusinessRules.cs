using Application.Features.Mesajs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Mesajs.Rules;

public class MesajBusinessRules : BaseBusinessRules
{
    private readonly IMesajRepository _mesajRepository;
    private readonly ILocalizationService _localizationService;

    public MesajBusinessRules(IMesajRepository mesajRepository, ILocalizationService localizationService)
    {
        _mesajRepository = mesajRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MesajsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MesajShouldExistWhenSelected(Mesaj? mesaj)
    {
        if (mesaj == null)
            await throwBusinessException(MesajsBusinessMessages.MesajNotExists);
    }

    public async Task MesajIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Mesaj? mesaj = await _mesajRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MesajShouldExistWhenSelected(mesaj);
    }
}