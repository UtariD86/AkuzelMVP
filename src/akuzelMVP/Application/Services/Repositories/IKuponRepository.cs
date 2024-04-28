using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IKuponRepository : IAsyncRepository<Kupon, Guid>, IRepository<Kupon, Guid>
{
}