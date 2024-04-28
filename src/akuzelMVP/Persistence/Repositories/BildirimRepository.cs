using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BildirimRepository : EfRepositoryBase<Bildirim, Guid, BaseDbContext>, IBildirimRepository
{
    public BildirimRepository(BaseDbContext context) : base(context)
    {
    }
}