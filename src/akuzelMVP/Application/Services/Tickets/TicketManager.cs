using Application.Features.Tickets.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Tickets;

public class TicketManager : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly TicketBusinessRules _ticketBusinessRules;

    public TicketManager(ITicketRepository ticketRepository, TicketBusinessRules ticketBusinessRules)
    {
        _ticketRepository = ticketRepository;
        _ticketBusinessRules = ticketBusinessRules;
    }

    public async Task<Ticket?> GetAsync(
        Expression<Func<Ticket, bool>> predicate,
        Func<IQueryable<Ticket>, IIncludableQueryable<Ticket, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Ticket? ticket = await _ticketRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return ticket;
    }

    public async Task<IPaginate<Ticket>?> GetListAsync(
        Expression<Func<Ticket, bool>>? predicate = null,
        Func<IQueryable<Ticket>, IOrderedQueryable<Ticket>>? orderBy = null,
        Func<IQueryable<Ticket>, IIncludableQueryable<Ticket, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Ticket> ticketList = await _ticketRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return ticketList;
    }

    public async Task<Ticket> AddAsync(Ticket ticket)
    {
        Ticket addedTicket = await _ticketRepository.AddAsync(ticket);

        return addedTicket;
    }

    public async Task<Ticket> UpdateAsync(Ticket ticket)
    {
        Ticket updatedTicket = await _ticketRepository.UpdateAsync(ticket);

        return updatedTicket;
    }

    public async Task<Ticket> DeleteAsync(Ticket ticket, bool permanent = false)
    {
        Ticket deletedTicket = await _ticketRepository.DeleteAsync(ticket);

        return deletedTicket;
    }
}
