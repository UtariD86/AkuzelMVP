using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MedyaRepository : EfRepositoryBase<Medya, Guid, BaseDbContext>, IMedyaRepository
{
    public MedyaRepository(BaseDbContext context) : base(context)
    {
    }
}