using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IListeRepository : IAsyncRepository<Liste, Guid>, IRepository<Liste, Guid>
{
}