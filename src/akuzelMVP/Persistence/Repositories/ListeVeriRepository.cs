using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ListeVeriRepository : EfRepositoryBase<ListeVeri, Guid, BaseDbContext>, IListeVeriRepository
{
    public ListeVeriRepository(BaseDbContext context) : base(context)
    {
    }
}