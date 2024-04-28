using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISiparisRepository : IAsyncRepository<Domain.Entities.Siparis, Guid>, IRepository<Domain.Entities.Siparis, Guid>
{
}