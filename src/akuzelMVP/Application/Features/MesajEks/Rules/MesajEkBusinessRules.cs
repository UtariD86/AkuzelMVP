using Application.Features.MesajEks.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MesajEks.Rules;

public class MesajEkBusinessRules : BaseBusinessRules
{
    private readonly IMesajEkRepository _mesajEkRepository;
    private readonly ILocalizationService _localizationService;

    public MesajEkBusinessRules(IMesajEkRepository mesajEkRepository, ILocalizationService localizationService)
    {
        _mesajEkRepository = mesajEkRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MesajEksBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MesajEkShouldExistWhenSelected(MesajEk? mesajEk)
    {
        if (mesajEk == null)
            await throwBusinessException(MesajEksBusinessMessages.MesajEkNotExists);
    }

    public async Task MesajEkIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MesajEk? mesajEk = await _mesajEkRepository.GetAsync(
            predicate: me => me.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MesajEkShouldExistWhenSelected(mesajEk);
    }
}