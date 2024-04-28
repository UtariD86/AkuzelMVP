using Application.Features.SistemGecmisis.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SistemGecmisis.Rules;

public class SistemGecmisiBusinessRules : BaseBusinessRules
{
    private readonly ISistemGecmisiRepository _sistemGecmisiRepository;
    private readonly ILocalizationService _localizationService;

    public SistemGecmisiBusinessRules(ISistemGecmisiRepository sistemGecmisiRepository, ILocalizationService localizationService)
    {
        _sistemGecmisiRepository = sistemGecmisiRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SistemGecmisisBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SistemGecmisiShouldExistWhenSelected(SistemGecmisi? sistemGecmisi)
    {
        if (sistemGecmisi == null)
            await throwBusinessException(SistemGecmisisBusinessMessages.SistemGecmisiNotExists);
    }

    public async Task SistemGecmisiIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        SistemGecmisi? sistemGecmisi = await _sistemGecmisiRepository.GetAsync(
            predicate: sg => sg.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SistemGecmisiShouldExistWhenSelected(sistemGecmisi);
    }
}