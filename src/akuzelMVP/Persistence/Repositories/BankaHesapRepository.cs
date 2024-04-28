using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BankaHesapRepository : EfRepositoryBase<BankaHesap, Guid, BaseDbContext>, IBankaHesapRepository
{
    public BankaHesapRepository(BaseDbContext context) : base(context)
    {
    }
}