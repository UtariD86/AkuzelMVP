using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BakiyeGecmisiRepository : EfRepositoryBase<BakiyeGecmisi, Guid, BaseDbContext>, IBakiyeGecmisiRepository
{
    public BakiyeGecmisiRepository(BaseDbContext context) : base(context)
    {
    }
}