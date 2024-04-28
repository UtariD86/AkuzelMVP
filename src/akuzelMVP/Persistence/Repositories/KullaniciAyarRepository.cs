using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class KullaniciAyarRepository : EfRepositoryBase<KullaniciAyar, Guid, BaseDbContext>, IKullaniciAyarRepository
{
    public KullaniciAyarRepository(BaseDbContext context) : base(context)
    {
    }
}