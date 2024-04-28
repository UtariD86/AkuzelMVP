using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class KullaniciBildirimRepository : EfRepositoryBase<KullaniciBildirim, Guid, BaseDbContext>, IKullaniciBildirimRepository
{
    public KullaniciBildirimRepository(BaseDbContext context) : base(context)
    {
    }
}