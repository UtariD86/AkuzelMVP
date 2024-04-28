using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ListeRepository : EfRepositoryBase<Liste, Guid, BaseDbContext>, IListeRepository
{
    public ListeRepository(BaseDbContext context) : base(context)
    {
    }
}