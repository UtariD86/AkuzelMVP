using Application.Features.Portfolyoes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Portfolyoes.Rules;

public class PortfolyoBusinessRules : BaseBusinessRules
{
    private readonly IPortfolyoRepository _portfolyoRepository;
    private readonly ILocalizationService _localizationService;

    public PortfolyoBusinessRules(IPortfolyoRepository portfolyoRepository, ILocalizationService localizationService)
    {
        _portfolyoRepository = portfolyoRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PortfolyoesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PortfolyoShouldExistWhenSelected(Portfolyo? portfolyo)
    {
        if (portfolyo == null)
            await throwBusinessException(PortfolyoesBusinessMessages.PortfolyoNotExists);
    }

    public async Task PortfolyoIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Portfolyo? portfolyo = await _portfolyoRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PortfolyoShouldExistWhenSelected(portfolyo);
    }
}