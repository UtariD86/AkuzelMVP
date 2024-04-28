using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class IlanRepository : EfRepositoryBase<Ilan, Guid, BaseDbContext>, IIlanRepository
{
    public IlanRepository(BaseDbContext context) : base(context)
    {
    }
}