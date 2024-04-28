using Application.Features.Tickets.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Tickets.Rules;

public class TicketBusinessRules : BaseBusinessRules
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ILocalizationService _localizationService;

    public TicketBusinessRules(ITicketRepository ticketRepository, ILocalizationService localizationService)
    {
        _ticketRepository = ticketRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TicketsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TicketShouldExistWhenSelected(Ticket? ticket)
    {
        if (ticket == null)
            await throwBusinessException(TicketsBusinessMessages.TicketNotExists);
    }

    public async Task TicketIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Ticket? ticket = await _ticketRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TicketShouldExistWhenSelected(ticket);
    }
}