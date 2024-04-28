using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITeklifRepository : IAsyncRepository<Teklif, Guid>, IRepository<Teklif, Guid>
{
}