using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PortfolyoRepository : EfRepositoryBase<Portfolyo, Guid, BaseDbContext>, IPortfolyoRepository
{
    public PortfolyoRepository(BaseDbContext context) : base(context)
    {
    }
}