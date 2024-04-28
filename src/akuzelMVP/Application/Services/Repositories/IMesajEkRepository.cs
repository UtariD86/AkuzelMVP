using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMesajEkRepository : IAsyncRepository<MesajEk, Guid>, IRepository<MesajEk, Guid>
{
}