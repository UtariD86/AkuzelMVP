using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBankaHesapRepository : IAsyncRepository<BankaHesap, Guid>, IRepository<BankaHesap, Guid>
{
}