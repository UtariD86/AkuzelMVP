using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITicketRepository : IAsyncRepository<Ticket, Guid>, IRepository<Ticket, Guid>
{
}