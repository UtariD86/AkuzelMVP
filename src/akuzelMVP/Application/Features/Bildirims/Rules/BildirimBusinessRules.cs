using Application.Features.Bildirims.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Bildirims.Rules;

public class BildirimBusinessRules : BaseBusinessRules
{
    private readonly IBildirimRepository _bildirimRepository;
    private readonly ILocalizationService _localizationService;

    public BildirimBusinessRules(IBildirimRepository bildirimRepository, ILocalizationService localizationService)
    {
        _bildirimRepository = bildirimRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BildirimsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BildirimShouldExistWhenSelected(Bildirim? bildirim)
    {
        if (bildirim == null)
            await throwBusinessException(BildirimsBusinessMessages.BildirimNotExists);
    }

    public async Task BildirimIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Bildirim? bildirim = await _bildirimRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BildirimShouldExistWhenSelected(bildirim);
    }
}