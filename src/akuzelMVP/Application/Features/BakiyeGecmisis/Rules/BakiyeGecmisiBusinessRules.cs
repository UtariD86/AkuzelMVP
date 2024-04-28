using Application.Features.BakiyeGecmisis.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BakiyeGecmisis.Rules;

public class BakiyeGecmisiBusinessRules : BaseBusinessRules
{
    private readonly IBakiyeGecmisiRepository _bakiyeGecmisiRepository;
    private readonly ILocalizationService _localizationService;

    public BakiyeGecmisiBusinessRules(IBakiyeGecmisiRepository bakiyeGecmisiRepository, ILocalizationService localizationService)
    {
        _bakiyeGecmisiRepository = bakiyeGecmisiRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BakiyeGecmisisBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BakiyeGecmisiShouldExistWhenSelected(BakiyeGecmisi? bakiyeGecmisi)
    {
        if (bakiyeGecmisi == null)
            await throwBusinessException(BakiyeGecmisisBusinessMessages.BakiyeGecmisiNotExists);
    }

    public async Task BakiyeGecmisiIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BakiyeGecmisi? bakiyeGecmisi = await _bakiyeGecmisiRepository.GetAsync(
            predicate: bg => bg.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BakiyeGecmisiShouldExistWhenSelected(bakiyeGecmisi);
    }
}