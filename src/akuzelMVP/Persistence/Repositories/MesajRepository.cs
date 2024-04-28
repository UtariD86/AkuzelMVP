using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MesajRepository : EfRepositoryBase<Mesaj, Guid, BaseDbContext>, IMesajRepository
{
    public MesajRepository(BaseDbContext context) : base(context)
    {
    }
}