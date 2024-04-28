using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Tickets;

public interface ITicketService
{
    Task<Ticket?> GetAsync(
        Expression<Func<Ticket, bool>> predicate,
        Func<IQueryable<Ticket>, IIncludableQueryable<Ticket, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Ticket>?> GetListAsync(
        Expression<Func<Ticket, bool>>? predicate = null,
        Func<IQueryable<Ticket>, IOrderedQueryable<Ticket>>? orderBy = null,
        Func<IQueryable<Ticket>, IIncludableQueryable<Ticket, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Ticket> AddAsync(Ticket ticket);
    Task<Ticket> UpdateAsync(Ticket ticket);
    Task<Ticket> DeleteAsync(Ticket ticket, bool permanent = false);
}
