using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class IlanListeRepository : EfRepositoryBase<IlanListe, Guid, BaseDbContext>, IIlanListeRepository
{
    public IlanListeRepository(BaseDbContext context) : base(context)
    {
    }
}