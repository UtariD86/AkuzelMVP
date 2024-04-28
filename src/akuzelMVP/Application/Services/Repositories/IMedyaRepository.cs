using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMedyaRepository : IAsyncRepository<Medya, Guid>, IRepository<Medya, Guid>
{
}