using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISistemGecmisiRepository : IAsyncRepository<SistemGecmisi, Guid>, IRepository<SistemGecmisi, Guid>
{
}