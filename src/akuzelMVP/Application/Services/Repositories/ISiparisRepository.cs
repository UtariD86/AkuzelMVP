using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISiparisRepository : IAsyncRepository<Siparis, Guid>, IRepository<Siparis, Guid>
{
}