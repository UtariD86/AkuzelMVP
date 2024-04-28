using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SiparisRepository : EfRepositoryBase<Siparis, Guid, BaseDbContext>, ISiparisRepository
{
    public SiparisRepository(BaseDbContext context) : base(context)
    {
    }
}