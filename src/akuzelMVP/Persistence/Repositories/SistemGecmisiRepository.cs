using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SistemGecmisiRepository : EfRepositoryBase<SistemGecmisi, Guid, BaseDbContext>, ISistemGecmisiRepository
{
    public SistemGecmisiRepository(BaseDbContext context) : base(context)
    {
    }
}