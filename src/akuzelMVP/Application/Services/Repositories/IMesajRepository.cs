using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMesajRepository : IAsyncRepository<Mesaj, Guid>, IRepository<Mesaj, Guid>
{
}