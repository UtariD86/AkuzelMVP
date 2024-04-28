using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBakiyeGecmisiRepository : IAsyncRepository<BakiyeGecmisi, Guid>, IRepository<BakiyeGecmisi, Guid>
{
}