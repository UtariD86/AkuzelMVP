using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TakimRepository : EfRepositoryBase<Takim, Guid, BaseDbContext>, ITakimRepository
{
    public TakimRepository(BaseDbContext context) : base(context)
    {
    }
}