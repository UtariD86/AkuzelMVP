using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TeklifRepository : EfRepositoryBase<Teklif, Guid, BaseDbContext>, ITeklifRepository
{
    public TeklifRepository(BaseDbContext context) : base(context)
    {
    }
}