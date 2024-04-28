using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MesajEkRepository : EfRepositoryBase<MesajEk, Guid, BaseDbContext>, IMesajEkRepository
{
    public MesajEkRepository(BaseDbContext context) : base(context)
    {
    }
}