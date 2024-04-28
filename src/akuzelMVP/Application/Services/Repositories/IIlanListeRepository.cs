using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IIlanListeRepository : IAsyncRepository<IlanListe, Guid>, IRepository<IlanListe, Guid>
{
}