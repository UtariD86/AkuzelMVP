using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class KuponRepository : EfRepositoryBase<Kupon, Guid, BaseDbContext>, IKuponRepository
{
    public KuponRepository(BaseDbContext context) : base(context)
    {
    }
}