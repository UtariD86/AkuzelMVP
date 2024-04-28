using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBildirimRepository : IAsyncRepository<Bildirim, Guid>, IRepository<Bildirim, Guid>
{
}