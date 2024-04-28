using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DegerlendirmeRepository : EfRepositoryBase<Degerlendirme, Guid, BaseDbContext>, IDegerlendirmeRepository
{
    public DegerlendirmeRepository(BaseDbContext context) : base(context)
    {
    }
}