using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TicketRepository : EfRepositoryBase<Ticket, Guid, BaseDbContext>, ITicketRepository
{
    public TicketRepository(BaseDbContext context) : base(context)
    {
    }
}