using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class KullaniciTakimRepository : EfRepositoryBase<KullaniciTakim, Guid, BaseDbContext>, IKullaniciTakimRepository
{
    public KullaniciTakimRepository(BaseDbContext context) : base(context)
    {
    }
}